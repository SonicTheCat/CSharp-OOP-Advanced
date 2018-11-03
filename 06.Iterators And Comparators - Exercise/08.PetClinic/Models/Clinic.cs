using System;
using System.Collections;
using System.Collections.Generic;

public class Clinic : IEnumerable<Pet>
{
    private int numberOfRooms;
    private string clinicName;
    private Pet[] roomsWithPets;
    private RoomTracker roomTracker;

    public Clinic(string name, int numberOFRooms)
    {
        this.clinicName = name;
        this.NumberOfRooms = numberOFRooms;
        this.roomsWithPets = new Pet[numberOfRooms];
        roomTracker = new RoomTracker(numberOFRooms);
    }

    public string ClinicName => this.clinicName;

    public Pet this[int index]
    {
        get
        {
            return this.roomsWithPets[index];
        }
        set
        {
            this.roomsWithPets[index] = value;
        }
    }

    public int NumberOfRooms
    {
        get
        {
            return this.numberOfRooms;
        }
        set
        {
            if (value % 2 == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            this.numberOfRooms = value;
        }
    }

    public bool HasEmptyRooms() => roomTracker.EmptyRooms > 0;

    public bool AddPet(Pet pet)
    {
        if (!(roomTracker.EmptyRooms > 0))
        {
            return false;
        }

        var index = roomTracker.GiveNextEmptyRoom();
        this.roomsWithPets[index] = pet;

        return true;
    }

    public bool ReleasePet()
    {
        bool isReleased = roomTracker
            .MakeEmptyRoom(this.roomsWithPets, roomTracker.StartingRoom, roomTracker.TotalRooms);

        if (isReleased)
        {
            return true;
        }
        return roomTracker.MakeEmptyRoom(this.roomsWithPets, 0, roomTracker.StartingRoom);
    }

    public IEnumerator<Pet> GetEnumerator()
    {
        foreach (var pet in this.roomsWithPets)
        {
            yield return pet;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}