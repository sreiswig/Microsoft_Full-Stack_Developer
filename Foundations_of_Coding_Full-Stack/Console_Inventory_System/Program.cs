using System;
using System.Data;

DataTable CreateInventoryTable() {
  DataTable table = new DataTable("Inventory");
  table.Columns.Add("Product Name", typeof(String));
  table.Columns.Add("Price", typeof(String));
  table.Columns.Add("Stock Quantity", typeof(String));
  return table;
}

void AddInventoryRow(String Product, String Price, String Quantity, DataTable table) {
  DataRow row = table.NewRow();
  row["Product Name"] = Product;
  row["Price"] = Price;
  row["Stock Quantity"] = Quantity;
  table.Rows.Add(row);
}

String MainMenu() {
  Console.WriteLine("""

      Inventory Management System enter one of the following to continue:
      Add, Update, Remove, View, Help, Exit
      """);
  return Console.ReadLine();
}

String UserInput = "";
do {
  DataTable InventoryTable = CreateInventoryTable();
  UserInput = MainMenu();
  switch (UserInput.ToLower())
  {
    case "add":
      Console.ForegroundColor = ConsoleColor.Green;
      while (true) {
        Console.WriteLine("Enter Product Name");
        String Product = Console.ReadLine();
        Console.WriteLine("Enter Product Price");
        String Price = Console.ReadLine();
        Console.WriteLine("Enter Stock Quantity");
        String Quantity = Console.ReadLine();
        AddInventoryRow(Product, Price, Quantity, InventoryTable);

        Console.WriteLine("Continue Adding? Y/N");
        String Continue = Console.ReadLine();
        if (Continue.ToLower() == "n") { break; }
      }
      Console.ResetColor();
      break;
    
    case "update":
      bool IsUpdating = true;
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.ResetColor();
      break;
    
    case "remove":
      bool IsRemoving = true;
      Console.ForegroundColor = ConsoleColor.Red;
      Console.ResetColor();
      break;
    
    case "view":
      Console.WriteLine(InventoryTable.Rows.Count);
      for (int i = 0; i < InventoryTable.Rows.Count; i++) {
        Console.WriteLine(InventoryTable.Rows[i]);
      }
      break;

    case "help":
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine("""

          Add: Add Products to the system
          Update: Update existing Products in the system
          Remove: Remove Products from the system
          View: View all Products currently in the system
          Help: View this screen
          Exit: Leave the Program
          """);
      Console.ResetColor();
      break;

    default:
      break;
  }
} while (UserInput.ToLower() != "exit");
