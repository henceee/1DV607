package program;


public class Main {

	public static void main(String[] args) {
		
        model.Server s=new model.Server();
        view.Console v=new view.Console();
        controller.Controller c=new controller.Controller();
        
        while(c.Dothings(v, s));

	}

}
