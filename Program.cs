using HelpDeskTicketSystem;
using System.Text.Json;

bool running = true;

string filePath = "tickets.json";

List<Ticket> tickets = new List<Ticket>();

if (File.Exists(filePath))
{
    string json = File.ReadAllText(filePath);

    List<Ticket>? savedTickets =
        JsonSerializer.Deserialize<List<Ticket>>(json);

    if (savedTickets != null)
    {
        tickets = savedTickets;
    }
}

int nextTicketId = 1;

if (tickets.Count > 0)
{
    nextTicketId = tickets.Max(ticket => ticket.TicketId) + 1;
}

while (running)
{
    Console.WriteLine("1. Create a Ticket");
    Console.WriteLine("2. View Tickets");
    Console.WriteLine("3. Update Ticket Status");
    Console.WriteLine("4. Delete Ticket");
    Console.WriteLine("5. Exit");

    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.WriteLine("Create Ticket selected");

        // Get name
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(name) ||
       !name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
        {
            Console.WriteLine("Please enter a valid name using letters only.");

            Console.Write("Enter your name: ");
            name = Console.ReadLine();
        }
        // Get issue
        Console.Write("What is the issue: ");
        string issue = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(issue))
        {
            Console.WriteLine("Please enter the issue.");

            Console.Write("Enter the issue: ");
            issue = Console.ReadLine();
        }


        Console.WriteLine("\nSelect issue category:");
        Console.WriteLine("1. Hardware");
        Console.WriteLine("2. Software");
        Console.WriteLine("3. Network");
        Console.WriteLine("4. Account/Login");
        Console.WriteLine("5. Other");

        string categoryChoice = Console.ReadLine();

        while (categoryChoice != "1" &&
               categoryChoice != "2" &&
               categoryChoice != "3" &&
               categoryChoice != "4" &&
               categoryChoice != "5")
        {
            Console.WriteLine("Invalid category. Please enter 1, 2, 3, 4 or 5.");
            categoryChoice = Console.ReadLine();
        }

        string category = "";

        if (categoryChoice == "1")
        {
            category = "Hardware";
        }
        else if (categoryChoice == "2")
        {
            category = "Software";
        }
        else if (categoryChoice == "3")
        {
            category = "Network";
        }
        else if (categoryChoice == "4")
        {
            category = "Account/Login";
        }
        else if (categoryChoice == "5")
        {
            category = "Other";
        }

        // Get priority
        Console.WriteLine("Select the level of urgency");
        Console.WriteLine("1. Low");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. High");

        string priorityChoice = Console.ReadLine();
        while (priorityChoice != "1" &&
            priorityChoice != "2" &&
            priorityChoice != "3")
        {
            Console.WriteLine("Invalid priority selected.Please enter either 1, 2, or 3");
            priorityChoice = Console.ReadLine();

        }
            string priorityLevel = "";

            if (priorityChoice == "1")
            {
                priorityLevel = "Low";
            }
            else if (priorityChoice == "2")
            {
                priorityLevel = "Medium";
            }
            else if (priorityChoice == "3")
            {
                priorityLevel = "High";
            }

            // Create ticket
            Ticket newTicket = new Ticket();

        newTicket.TicketId = nextTicketId;
        newTicket.Name = name;
        newTicket.Issue = issue;
        newTicket.Category = category;
        newTicket.Priority = priorityLevel;
        newTicket.Status = "Open";
        newTicket.CreatedAt = DateTime.Now;

        tickets.Add(newTicket);
            nextTicketId++;
        string json = JsonSerializer.Serialize(
    tickets,
    new JsonSerializerOptions { WriteIndented = true }
);

        File.WriteAllText(filePath, json);

        Console.WriteLine("\nTicket created!");
            Console.WriteLine("Name: " + newTicket.Name);
            Console.WriteLine("Issue: " + newTicket.Issue);
            Console.WriteLine("Priority: " + newTicket.Priority);
            Console.WriteLine("Ticket ID: " + newTicket.TicketId);

            if (priorityChoice == "3")
            {
                Console.WriteLine(
                    "Status: Open - Your matter will be handled urgently!"
                );
            }
            else
            {
                Console.WriteLine("Status: Open");
            }
        }
    

    else if (choice == "2")
    {
        Console.WriteLine("\n===== ALL TICKETS =====");

        if (tickets.Count == 0)
        {
            Console.WriteLine("No tickets found");
        }
        else
        {
            foreach (Ticket ticket in tickets)
            {
                Console.WriteLine("Ticket ID: " + ticket.TicketId);
                Console.WriteLine("Name: " + ticket.Name);
                Console.WriteLine("Issue: " + ticket.Issue);
                Console.WriteLine("Category: " + ticket.Category);
                Console.WriteLine("Priority: " + ticket.Priority);
                Console.WriteLine("Status: " + ticket.Status);
                Console.WriteLine("Created: " + ticket.CreatedAt);
                Console.WriteLine("-----------------------");
            }
        }
    }

    else if (choice == "3")
    {
        Console.WriteLine("\n===== UPDATE TICKET STATUS =====");

        Console.Write("Enter Ticket ID: ");
        string ticketInput = Console.ReadLine();

        int ticketId;

        bool isValid = int.TryParse(ticketInput, out ticketId);

        if (isValid == false)
        {
            Console.WriteLine("Invalid Ticket ID.");


        }
        else
        {
            bool ticketFound = false;

            foreach (Ticket ticket in tickets)
            {
                if (ticket.TicketId == ticketId)
                {
                    ticketFound = true;

                    Console.WriteLine("Ticket found!");
                    Console.WriteLine("Issue: " + ticket.Issue);
                    Console.WriteLine(
                        "Current status: " + ticket.Status
                    );

                    Console.WriteLine("\nSelect new status:");
                    Console.WriteLine("1. Open");
                    Console.WriteLine("2. In Progress");
                    Console.WriteLine("3. Resolved");

                    Console.Write("Choose an option: ");
                    string statusChoice = Console.ReadLine();

                    while (statusChoice != "1" &&
                           statusChoice != "2" &&
                           statusChoice != "3")
                    {
                        Console.WriteLine("Invalid status. Please enter either 1, 2, or 3.");
                        statusChoice = Console.ReadLine();
                    }

                    if (statusChoice == "1")
                    {
                        ticket.Status = "Open";
                        Console.WriteLine("Status updated to Open.");
                    }
                    else if (statusChoice == "2")
                    {
                        ticket.Status = "In Progress";
                        Console.WriteLine("Status updated to In Progress.");
                    }
                    else if (statusChoice == "3")
                    {
                        ticket.Status = "Resolved";
                        Console.WriteLine("Status updated to Resolved.");
                    }

                    string json = JsonSerializer.Serialize(
    tickets,
    new JsonSerializerOptions { WriteIndented = true }
);

                    File.WriteAllText(filePath, json);
                }
            }

            if (ticketFound == false)
            {
                Console.WriteLine("Ticket not found.");
            }
        }
    }

        else if (choice == "4")
        {
            Console.WriteLine("\n===== DELETE TICKET =====");

            Console.Write("Enter Ticket ID: ");
            string ticketInput = Console.ReadLine();

            int ticketId;

            bool isValid = int.TryParse(ticketInput, out ticketId);

            if (isValid == false)
            {
                Console.WriteLine("Invalid Ticket ID.");
            }
            else
            {
                Ticket ticketToDelete = null;

                foreach (Ticket ticket in tickets)
                {
                    if (ticket.TicketId == ticketId)
                    {
                        ticketToDelete = ticket;
                        break;
                    }
                }

                if (ticketToDelete == null)
                {
                    Console.WriteLine("Ticket not found.");
                }
                else
                {
                    Console.WriteLine("Ticket found:");
                    Console.WriteLine("Issue: " + ticketToDelete.Issue);

                    Console.Write("Are you sure you want to delete this ticket? (Y/N): ");
                    string confirmation = Console.ReadLine();

                    if (confirmation.ToUpper() == "Y")
                    {
                        tickets.Remove(ticketToDelete);

                        string json = JsonSerializer.Serialize(
                            tickets,
                            new JsonSerializerOptions { WriteIndented = true }
                        );

                        File.WriteAllText(filePath, json);

                        Console.WriteLine("Ticket deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Deletion cancelled.");
                    }
                }
            }
        }
    
    else if (choice == "5")
    {
        Console.WriteLine("Exiting");
        running = false;
    }
    else
    {
        Console.WriteLine("Invalid option");
    }
}