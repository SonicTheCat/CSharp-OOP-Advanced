using System;
using System.Collections.Generic;
using System.Linq;

public class Controller
{
    private List<Pet> pets;
    private List<Clinic> clinics;

    public Controller()
    {
        pets = new List<Pet>();
        clinics = new List<Clinic>();
    }

    public void HasEmptyRooms(string name)
    {
        var clinic = this.clinics.FirstOrDefault(x => x.ClinicName == name);
        Print(clinic.HasEmptyRooms());
    }

    public void Create(string[] tokens)
    {
        if (tokens[0] == "Pet")
        {
            this.CreatePet(tokens.Skip(1).ToArray());
        }
        else if (tokens[0] == "Clinic")
        {
            this.CreateClinic(tokens.Skip(1).ToArray());
        }
    }

    private void CreatePet(string[] tokens)
    {
        var name = tokens[0];
        var age = int.Parse(tokens[1]);
        var kind = tokens[2];

        pets.Add(new Pet(name, age, kind));
    }

    private void CreateClinic(string[] tokens)
    {
        var name = tokens[0];
        var countOfRooms = int.Parse(tokens[1]);

        clinics.Add(new Clinic(name, countOfRooms));
    }

    public void Add(string[] tokens)
    {
        var clinicName = tokens[1];
        var petName = tokens[0];
        var clinic = this.clinics.FirstOrDefault(x => x.ClinicName == clinicName);
        var pet = this.pets.FirstOrDefault(x => x.Name == petName);

        if (pet == null)
        {
            throw new ArgumentException("Invalid Operation!");
        }

        Print(clinic.AddPet(pet));
    }

    public void Release(string clinicName)
    {
        var clinic = this.clinics.FirstOrDefault(x => x.ClinicName == clinicName);
        Print(clinic.ReleasePet());
    }

    public void PreparePrint(string[] tokens)
    {
        var clinic = clinics.FirstOrDefault(x => x.ClinicName == tokens[0]);
        if (tokens.Length == 1)
        {
            foreach (var room in clinic)
            {
                IsRoomOcupied(room);
            }
        }
        else
        {
            var roomNumber = int.Parse(tokens[1]);
            IsRoomOcupied(clinic[roomNumber - 1]);
        }
    }

    private void Print<T>(T value)
    {
        Console.WriteLine(value);
    }

    private void IsRoomOcupied(Pet room)
    {
        if (room != null)
        {
            Print(room);
        }
        else
        {
            Print("Room empty");
        }
    }
}