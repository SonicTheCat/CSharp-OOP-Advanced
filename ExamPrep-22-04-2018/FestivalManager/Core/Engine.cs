namespace FestivalManager.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;

    /// <summary>
    /// by g0shk0
    /// </summary>
    class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IFestivalController festivalController, ISetController setController, IReader reader, IWriter writer)
        {
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true) // for job security
            {
                var input = reader.ReadLine();

                if (input == "END")
                    break;

                try
                {
                    string.Intern(input);

                    var result = this.ProcessCommand(input);
                        this.writer.WriteLine(result);
                }
                catch (InvalidOperationException ex) // in case we run out of memory
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var splitedInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var command = splitedInput.First();
            var tokens = splitedInput.Skip(1).ToArray();

            if (command == "LetsRock")
            {
                return this.setCоntroller.PerformSets();
            }

            var method = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

            string result = null;

            try
            {
                result = (string)method.Invoke(this.festivalCоntroller, new object[] { tokens });
            }
            catch (TargetInvocationException up)
            {
                throw new InvalidOperationException(up.InnerException.Message); 
            }
            return result;
        }
    }
}