using WishList.Core.Models;

namespace WishList.Core.Validations
{
    public static class WishTitleValidator
    {
        public static bool IsValid(Wish wish)
        {
            return !string.IsNullOrEmpty(wish.Title);
        }
    }
}
