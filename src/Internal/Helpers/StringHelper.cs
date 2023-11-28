namespace Internal.Helpers;

public static class StringHelper
{
    public static string GetCreateOrEditAction(bool isCreate) => isCreate ? "Vytvoriť" : "Upraviť";
}
