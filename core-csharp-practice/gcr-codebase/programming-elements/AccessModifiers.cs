using System;
class Parent{
	
	
	
	
	/*public	            Anywhere
  private	            Same class only
  protected	            Same class + child class
  internal	            Same project/assembly
  protected internal	Same project OR child class
  private protected	    Same class OR child class in same project*/
  
  
  
  
	public int publica=1;
	private int privatea=2;
	protected int procteda=3;
	internal int internala=4;
	protected internal int  prointernala=50;

	public void Showp(){
		Console.WriteLine("Inside parent class");
		Console.WriteLine(publica);
		Console.WriteLine(privatea);
		Console.WriteLine(procteda);
		Console.WriteLine(internala);
		 Console.WriteLine(prointernala);
		
	}
}
class Child:Parent{
	public void Showc(){
		Console.WriteLine("Inside child class");
		Console.WriteLine(publica);
		Console.WriteLine(procteda);
		Console.WriteLine(internala);
		Console.WriteLine(prointernala);
	
		
	}
}
class Other{
	public void Showo(){
		Parent p=new Parent();
		Console.WriteLine("Inside other class");
		Console.WriteLine(p.publica);
		Console.WriteLine(p.internala);
		Console.WriteLine(p.prointernala);
		
		
	}
}
class AccessModifiers{
public static void Main(string []args){
Parent pa=new Parent();
pa.Showp();
Child ch=new Child();
ch.Showc();
Other oi=new Other();
oi.Showo();

}
}