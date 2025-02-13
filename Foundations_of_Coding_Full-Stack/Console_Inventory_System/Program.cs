using System;
using System.Data;

DataTable CreateInventoryTable() {
  DataTable table = new DataTable("Inventory");
  table.Columns.Add("Product Name", typeof(String));
  table.Columns.Add("Price", typeof(String));
  table.Columns.Add("Stock Quantity", typeof(String));
  return table;
}

void PrintTable(DataTable table) {
  Console.WriteLine(table.Rows.Count + " Rows in the Inventory System");
  int currentRow = 0;
  foreach(DataRow dataRow in table.Rows) {
    Console.Write(currentRow);
    foreach(var item in dataRow.ItemArray) {
      Console.Write(" " + item);
    }
    currentRow++;
    Console.WriteLine();
  }
}

void AddInventoryRow(String Product, String Price, String Quantity, DataTable table) {
  DataRow row = table.NewRow();
  row["Product Name"] = Product;
  row["Price"] = Price;
  row["Stock Quantity"] = Quantity;
  table.Rows.Add(row);
  PrintTable(table);
}

void UpdateInventoryRow(String Product, String Price, String Quantity, int index, DataTable table) {
  
}

void DeleteInventoryRow(int index, DataTable table) {
  table.Rows.RemoveAt(index);
}

String MainMenu() {
  Console.WriteLine("""

      Inventory Management System enter one of the following to continue:
      Add, Update, Remove, View, Help, Exit
      """);
  return Console.ReadLine();
}

String UserInput = "";
DataTable InventoryTable = CreateInventoryTable();
do {
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

        Console.WriteLine("Continue Adding? Y");
        String Continue = Console.ReadLine();
        if (Continue.ToLower() != "y") { break; }
      }
      Console.ResetColor();
      break;
    
    case "update":
      bool IsUpdating = true;
      Console.ForegroundColor = ConsoleColor.Yellow;
      while (true) {
        PrintTable(InventoryTable);
        Console.WriteLine("Enter the row number to update");
        String input = Console.ReadLine();
        if (Int32.TryParse(input, out int j)) {
          Console.WriteLine("Enter Updated Product");
          String Product = Console.ReadLine();
          Console.WriteLine("Enter Updated Price");
          String Price = Console.ReadLine();
          Console.WriteLine("Enter Updated Stock");
          String Stock = Console.ReadLine();

        } else {
          Console.WriteLine("Not a valid row number");
        }
        Console.WriteLine("Continue Updating? Y");
        String Continue = Console.ReadLine();
        if (Continue.ToLower() != "y") { break; }
      }
      Console.ResetColor();
      break;
    
    case "remove":
      bool IsRemoving = true;
      Console.ForegroundColor = ConsoleColor.Red;
      while (true) {
        PrintTable(InventoryTable);
        Console.WriteLine("Enter the number of the row to remove");
        String input = Console.ReadLine();
        if (Int32.TryParse(input, out int j)) {
          Console.WriteLine("Deleting Row: " + j);
          DeleteInventoryRow(j, InventoryTable);
        } else {
          Console.WriteLine("Not a valid row number");
        }
        Console.WriteLine("Continue Removing? Y");
        String Continue = Console.ReadLine();
        if (Continue.ToLower() != "y") { break; }
      }
      Console.ResetColor();
      break;
    
    case "view":
      PrintTable(InventoryTable);
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
