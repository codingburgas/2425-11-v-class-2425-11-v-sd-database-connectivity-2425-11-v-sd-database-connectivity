﻿using ReadFromDatabase.Data;

namespace ReadFromDatabase;

class Program
{
    static void Main(string[] args)
    {
        TicketManagementDatabaseContext context = new TicketManagementDatabaseContext();
        
        context.CheckConnection();
    }
}