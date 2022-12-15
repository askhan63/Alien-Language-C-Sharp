public abstract class Line
{
    protected int start_x,start_y,length;
    protected char theCharacter;
    public Line(int s,int y,int l)
    {
        start_x = s;
        start_y = y;
        length = l;
    }
    public char GetCharacter()
    {
        return theCharacter;
    }
    public abstract bool onLine(int x,int y);

}
public class Horizental : Line
{
    public Horizental(int x,int y,int len) : base(x,y,len)
    {
        theCharacter = '-';
    }

    public override bool onLine(int x, int y)
    {
        if (x == start_x &&  y >= start_y && y  <= start_y + length-1)
            return true;
        else
        return false;
    }
}
public class VerticleLine: Line
{
    public VerticleLine(int x, int y, int len) : base(x, y, len)
    {
        theCharacter = '|';
    }
    public override bool onLine(int x, int y)
    {
        if (y == start_y &&x>=start_x  && x <= start_x + length-1)
            return true;
        else
            return false;

    }
}
public class FakeCharacter
{
    char[,] charArray;
    int size;
    List<Line> list=new List<Line>();
    public void createPath(int x)
    {
        Random random = new Random();
        for (int i = 0; i < x; i++)
        {
            int xVal = random.Next(0,charArray.GetLength(0));
            int yVal = random.Next(0, charArray.GetLength(1));
            int leng = random.Next(0,size);
            int choos = random.Next(0, 2);
            Line l;
            if (choos == 0)
            {
               l=  new Horizental(xVal, yVal, leng);
            }
            else
            {
              l=   new VerticleLine(xVal, yVal, leng);

            }
            list.Add(l);
        }
    }
    public void addCircles(int num)
    {
        Random r = new Random();
        for (int i = 1; i <= num; i++) {
            int x = r.Next(0, charArray.GetLength(0));
            int y = r.Next(0, charArray.GetLength(1));
            charArray[x, y] = 'O';
        }
    }
    public FakeCharacter(int s,int num)
    {
        charArray = new char[s, s];
        this.size = s;
        createPath(num);
        for(int i = 0; i < charArray.GetLength(0) ; i++)
        {
            for(int j=0; j < charArray.GetLength(1); j++)
            {
                foreach(var x in list)
                {
                    if (x.onLine(i, j))
                        charArray[i, j] = x.GetCharacter();
                }
            
            }
        }
        addCircles(4);
    }
    public void PrintCharacter()
    {
        for (int i = 0; i < charArray.GetLength(0); i++)
        {
            for (int j = 0; j < charArray.GetLength(1); j++)
            {
                if(charArray[i,j] == '\u0000')
                {
                    Console.Write(" ");

                }
                else
                {
                    Console.Write(charArray[i,j]);
                }
            }
            Console.WriteLine();
        }
    }
}
class Program
{
    static void Main()
    {
        for (int i = 0; i < 5; i++)
        {
            FakeCharacter myChar = new FakeCharacter(5, 10);
            myChar.PrintCharacter();
            Console.WriteLine("~~~~~~~");
        }
    }

}
