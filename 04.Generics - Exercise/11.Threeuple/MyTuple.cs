public class MyTuple<T1, T2, T3>
{
    public MyTuple(T1 item1, T2 item2, T3 item3)
    {
        this.FirstItem = item1;
        this.SecondItem = item2;
        this.ThirdItem = item3;
    }

    public T1 FirstItem { get; set; }

    public T2 SecondItem { get; set; }

    public T3 ThirdItem { get; set; }
}