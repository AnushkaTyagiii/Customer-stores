using customers;
using customers.Data_model;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            AddCustomer(context, 148, "A", 28.6129, 77.2295);
            AddStore(context, 817, "Store2", 28.6219, 77.2295);
            context.SaveChanges();
            var stores = GetStorewiradius(context, 28.6129, 77.2295);
            if (stores.Count == 0)
            {
                Console.WriteLine("No stores found within 10km radius.");
            }
            else
            {
                foreach (var store in stores)
                {
                    Console.WriteLine($"Store within 10km radius: {store.Store_name}");
                }
            }
            Console.ReadKey();
        }
    }

    private static void AddCustomer(AppDbContext context, int cid, string customername, double latitude, double longitude)
    {
        var customer = new customers.Data_model.Customers
        {
            Customer_id = cid,
            Customer_name = customername,
            Customer_lat = latitude,
            Customer_long = longitude
        };
        context.Customers.Add(customer);

    }

    private static void AddStore(AppDbContext context, int sid, string storename, double latitude, double longitude)
    {
        var store = new customers.Data_model.Stores
        {
            Store_id = sid,
            Store_name = storename,
            Store_lat = latitude,
            Store_long = longitude
        };
        context.Stores.Add(store);

    }

    private static double Caldis(double lat1, double lon1, double lat2, double lon2)
    {
        double dLat = (lat2 - lat1) * (Math.PI / 180);
        double dLon = (lon2 - lon1) * (Math.PI / 180);

        lat1 = lat1 * (Math.PI / 180);
        lat2 = lat2 * (Math.PI / 180);

        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(lat1) * Math.Cos(lat2) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        double distance = 6371 * c;
        return distance;
    }

    private static List<Stores> GetStorewiradius(AppDbContext context, double clat, double clon)
    {
        var allStores = context.Stores.AsEnumerable();
        return allStores
        .Where(store => Caldis(clat, clon, store.Store_lat, store.Store_long) <= 10)
        .ToList();
    }
}

