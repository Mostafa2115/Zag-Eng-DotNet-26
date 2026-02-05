using System;
using System.Runtime.InteropServices;
class Program
{
    static void ModifyUser(User user)
    {
        user.Name = "Modified Name";
        user.Age += 1;
    }
    static void ModifyUserRef(ref User user)
    {
        user.Name = "Modified Ref Name";
        user.Age += 1;
    }
    static void ModifyUserSnapshot(UserSnapshot snapshot)
    {
        snapshot.Name = "Modified Snapshot Name";
        snapshot.Age += 1;
    }
    static void ModifyUserSnapshotRef(ref UserSnapshot snapshot)
    {
        snapshot.Name = "Modified Snapshot Ref Name";
        snapshot.Age += 1;
    }
    static void Main(string[] args)
    {
        User user = new User { Name = "mostafa", Age = 30 };
        ModifyUser(user);
        ModifyUserRef(ref user);
        Console.WriteLine($"User: {user.Name}, Age: {user.Age}");
        UserSnapshot snapshot = new UserSnapshot { Name = "mostafa2222", Age = 30 };
        ModifyUserSnapshot(snapshot);
        ModifyUserSnapshotRef(ref snapshot);
        Console.WriteLine($"UserSnapshot: {snapshot.Name}, Age: {snapshot.Age}");
    }
}

class User
{
    public string Name { get; set; }
    public int Age { get; set; }
}
struct UserSnapshot
{
    public string Name { get; set; }
    public int Age { get; set; }
}


