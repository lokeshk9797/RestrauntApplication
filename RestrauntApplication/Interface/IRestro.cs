using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrauntApplication.Interface
{
    public interface IRestro
    {
        void SetTables();
        void SetItems();
        void SetMenu();
        int ShowMenuList();
        void ShowTableList(bool availability);
        void ShowItemList(bool availability);
        void SetOrder(int itemId, int quantity);
        void ReserveTable(int tableId);
        void OrderCompleted(Guid userId,String CustomerName);
        void ShowOrderedItems(Guid userId);
        void ActionToPerformedByAdminChoice(int choice);
        void ShowCustomers();


    }
}
