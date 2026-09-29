using HelpDeskTicketSystem;

bool running = true;

List<Ticket> tickets = new List<Ticket>();
int nextTicketId = 1;

while (running)
{

    Console.WriteLine("===== IT HELP DESK =====");
    Console.WriteLine("1. Create a Ticket");
    Console.WriteLine("2. View Tickets");
    Console.WriteLine("3. Update Ticket Status");
    Console.WriteLine("4. Exit");

    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.WriteLine("Create Ticket selected");

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("What is the issue: ");
        string issue = Console.ReadLine();

        Console.WriteLine("Select the level of urgency");
        Console.WriteLine("1. Low");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. High");

        string priority = Console.ReadLine();

        Ticket newTicket = new Ticket();
        newTicket.TicketId = nextTicketId;
        newTicket.Name = name;
        newTicket.Issue = issue;
        newTicket.Priority = priority;
        newTicket.Status = "Open";

        tickets.Add(newTicket);
        nextTicketId++;

        Console.WriteLine("\nTicket created!");
        Console.WriteLine("Name: " + newTicket.Name);
        Console.WriteLine("Issue: " + newTicket.Issue);
        Console.WriteLine("Ticket ID: " + newTicket.TicketId);

        if (priority == "3")
        {
            Console.WriteLine("Status: Open - Your matter will be handled urgently!");
        }
        else if (priority == "1" || priority == "2")
        {
            Console.WriteLine("Status: Open");
        }
        else
        {
            Console.WriteLine("Invalid priority selected.");
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
                Console.WriteLine("Name: " + ticket.Name);
                Console.WriteLine("Issue: " + ticket.Issue);
                Console.WriteLine("Priority: " + ticket.Priority);
                Console.WriteLine("Status: " + ticket.Status);
                Console.WriteLine("Ticket ID: " + ticket.TicketId);
                Console.WriteLine("-----------------------");
            }
        }
    }

    else if (choice == "3")
    {
        Console.WriteLine("\n===== UPDATE TICKET STATUS =====");

        Console.Write("Enter Ticket ID: ");
        string ticketId = Console.ReadLine();
    }

    else if (choice == "4")
    {
        Console.WriteLine("Exiting");
        running = false;
    }
    else
    {
        Console.WriteLine("Invalid option");
    }

}

