namespace E_Commerce.Domain.Enums
{
    public enum Permission
    {
        User_Permission,
        Role_Permission,
        User_Role_Permission,
        User_Claim_Permission,
        Role_Claim_Permission,

        Attribute_Read,
        Attribute_Write,
        Attribute_Delete,

        Brand_Read,
        Brand_Write,
        Brand_Delete,

        Category_Read,
        Category_Write,
        Category_Delete,

        Coupon_Read,
        Coupon_Write,
        Coupon_Delete,

        Product_Read,
        Product_Write,
        Product_Delete
    }
}
