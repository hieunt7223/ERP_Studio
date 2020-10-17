namespace xdcb.BookStore
{
    public class BookStorePermissions
    {
        public const string GroupName = "BookStore";

        public static class BookStore
        {
            public const string Default = GroupName + ".Permission";
            public const string Management = Default + ".Read";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }
    }
}
