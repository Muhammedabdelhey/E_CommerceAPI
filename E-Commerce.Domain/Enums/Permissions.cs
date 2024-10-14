namespace E_Commerce.Domain.Enums
{
    public enum Permissions
    {
        User_Permission = 0,
        Role_Permission = 1,
        User_Role_Permission = 2,
        User_Claim_Permission = 3,
        Role_Claim_Permission = 4,

        Attribute_Read = 5,
        Attribute_Write = 6,
        Attribute_Delete = 7,

        Brand_Read = 8,
        Brand_Write = 9,
        Brand_Delete = 10,

        Category_Read = 11,
        Category_Write = 12,
        Category_Delete = 13,

        Coupon_Read = 14,
        Coupon_Write = 15,
        Coupon_Delete = 16,

        Product_Read = 17,
        Product_Write = 18,
        Product_Delete = 19
    }
}
