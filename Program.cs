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


        string priorityChoice = Console.ReadLine();

        if (priorityChoice != "1" && priorityChoice != "2" && priorityChoice != "3")
        {
            Console.WriteLine("Invalid priority selected.");
        }
        else
        {
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

            Ticket newTicket = new Ticket();
            newTicket.TicketId = nextTicketId;
            newTicket.Name = name;
            newTicket.Issue = issue;
            newTicket.Priority = priorityLevel;
            newTicket.Status = "Open";

            tickets.Add(newTicket);
            nextTicketId++;

            Console.WriteLine("\nTicket created!");
            Console.WriteLine("Name: " + newTicket.Name);
            Console.WriteLine("Issue: " + newTicket.Issue);
            Console.WriteLine("Priority: " + newTicket.Priority);
            Console.WriteLine("Ticket ID: " + newTicket.TicketId);

            if (priorityChoice == "3")
            {
                Console.WriteLine("Status: Open - Your matter will be handled urgently!");
            }
            else
            {
                Console.WriteLine("Status: Open");
            }
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
                    Console.WriteLine("Current status: " + ticket.Status);

                    Console.WriteLine("\nSelect new status:");
                    Console.WriteLine("1. Open");
                    Console.WriteLine("2. In Progress");
                    Console.WriteLine("3. Resolved");

                    Console.Write("Choose an option: ");
                    string statusChoice = Console.ReadLine();

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
                    else
                    {
                        Console.WriteLine("Invalid status option.");
                    }
                    
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
        Console.WriteLine("Exiting");
        running = false;
    }
    else
    {
        Console.WriteLine("Invalid option");
    }

}

