function show_errr1()
{
    var total=$('#hdn_total').val();
   
    if(total>=0)
    {
        var f= document.getElementById("gvSensinfo");
        for(var i=0; i<f.getElementsByTagName("input").length ;i++ )
        {
            if(f.getElementsByTagName("input").item(i).type == "text" )
            {
                shw1(f.getElementsByTagName("input").item(i).id,f,i);

            }  
        }  
            
    }
   
}
function shw1(id,obj,i)
{

    var total=$('#hdn_total').val();
    if(i==0)
    {
        if((document.getElementById(id).value)=="" || (document.getElementById(id).value) == null && i==0)
        {
                alert("Please Enter Tol.Min Value");
                obj.getElementsByTagName("input").item(0).focus();
                return false;
        }
        else
        {
            return true;
        }
    }
}

function show_errr2()
{
    var total=$('#hdn_total').val();
   
    if(total>=0)
    {
        var f= document.getElementById("gvSensinfo");
        for(var i=0; i<f.getElementsByTagName("input").length ;i++ )
        {
            if(f.getElementsByTagName("input").item(i).type == "text" )
            {
                shw2(f.getElementsByTagName("input").item(i).id,f,i);

            }  
        }  
            
    }
   
}
function shw2(id,obj,i)
{

     var total=$('#hdn_total').val();
    if(i==1)
    {
        if((document.getElementById(id).value)=="" || (document.getElementById(id).value) == null && i==1)
        {
                alert("Please Enter visual Value");
                obj.getElementsByTagName("input").item(1).focus();
                return false;
        }
        else
        {
            
        return true;
        }
    }
}
function show_errr()
{
    var total=$('#hdn_total').val();
   
    if(total==15 || total==0)
    {
        var f= document.getElementById("gvSensinfo");
        for(var i=0; i<f.getElementsByTagName("input").length ;i++ )
        {
            if(f.getElementsByTagName("input").item(i).type == "text" )
            {
                shw(f.getElementsByTagName("input").item(i).id,f,i);

            }  
        }  
            
    }
   
}
function shw(id,obj,i)
{
//     var total=$('#hdn_total').val();
//    if((i==2) && (total==15 || total==0))
//    {
//        if((document.getElementById(id).value)=="" || (document.getElementById(id).value) == null && i==2)
//        {
//                alert("Please Enter CMM Value");
//                obj.getElementsByTagName("input").item(2).focus();
//                return false;
//        }
//        else
//        {
//            
//        return true;
//        }
//    }
}

function show_errr3()
{
    var total=$('#hdn_total').val();
   
    if(total>=0)
    {
        var f= document.getElementById("gvSensinfo");
        for(var i=0; i<f.getElementsByTagName("input").length ;i++ )
        {
            if(f.getElementsByTagName("input").item(i).type == "text" )
            {
                shw3(f.getElementsByTagName("input").item(i).id,f,i);

            }  
        }  
            
    }
   
}
function shw3(id,obj,i)
{

     var total=$('#hdn_total').val();
    if(i==3)
    {
        if((document.getElementById(id).value)=="" || (document.getElementById(id).value) == null && i==3)
        {
                alert("Please Enter HeatCode No Value");
                obj.getElementsByTagName("input").item(3).focus();
                return false;
        }
        else
        {
            
        return true;
        }
    }
}
function show_errr4()
{
    var total=$('#hdn_total').val();
   
    if(total>=0)
    {
        var f= document.getElementById("gvSensinfo");
        for(var i=0; i<f.getElementsByTagName("input").length ;i++ )
        {
            if(f.getElementsByTagName("input").item(i).type == "text" )
            {
                shw4(f.getElementsByTagName("input").item(i).id,f,i);

            }  
        }  
            
    }
   
}
function shw4(id,obj,i)
{

     var total=$('#hdn_total').val();
    if(i==4)
    {
        if((document.getElementById(id).value)=="" || (document.getElementById(id).value) == null && i==4)
        {
                alert("Please Enter Pos1 Value");
                obj.getElementsByTagName("input").item(4).focus();
                return false;
        }
        else
        {
            
        return true;
        }
    }
}

function show_errr5()
{
    var total=$('#hdn_total').val();
   
    if(total>=0)
    {
        var f= document.getElementById("gvSensinfo");
        for(var i=0; i<f.getElementsByTagName("input").length ;i++ )
        {
            if(f.getElementsByTagName("input").item(i).type == "text" )
            {
                shw5(f.getElementsByTagName("input").item(i).id,f,i);

            }  
        }  
            
    }
   
}
function shw5(id,obj,i)
{

     var total=$('#hdn_total').val();
    if(i==5)
    {
        if((document.getElementById(id).value)=="" || (document.getElementById(id).value) == null && i==5)
        {
                alert("Please Enter Pos2 Value");
                obj.getElementsByTagName("input").item(5).focus();
                return false;
        }
        else
        {
            
        return true;
        }
    }
}
function show_errr6()
{
    var total=$('#hdn_total').val();
   
    if(total>=0)
    {
        var f= document.getElementById("gvSensinfo");
        for(var i=0; i<f.getElementsByTagName("input").length ;i++ )
        {
            if(f.getElementsByTagName("input").item(i).type == "text" )
            {
                shw6(f.getElementsByTagName("input").item(i).id,f,i);

            }  
        }  
            
    }
   
}
function shw6(id,obj,i)
{

     var total=$('#hdn_total').val();
    if(i==6)
    {
        if((document.getElementById(id).value)=="" || (document.getElementById(id).value) == null && i==6)
        {
                alert("Please Enter Pos1 Value");
                obj.getElementsByTagName("input").item(6).focus();
                return false;
        }
        else
        {
            
        return true;
        }
    }
}

function show_errr7()
{
    var total=$('#hdn_total').val();
   
    if(total>=0)
    {
        var f= document.getElementById("gvSensinfo");
        for(var i=0; i<f.getElementsByTagName("input").length ;i++ )
        {
            if(f.getElementsByTagName("input").item(i).type == "text" )
            {
                shw7(f.getElementsByTagName("input").item(i).id,f,i);

            }  
        }  
            
    }
   
}
function shw7(id,obj,i)
{

     var total=$('#hdn_total').val();
    if(i==7)
    {
        if((document.getElementById(id).value)=="" || (document.getElementById(id).value) == null && i==7)
        {
                alert("Please Enter Pos2 Value");
                obj.getElementsByTagName("input").item(7).focus();
                return false;
        }
        else
        {
            
        return true;
        }
    }
}
function show_errr8()
{
    var total=$('#hdn_total').val();
   
    if(total>=0)
    {
        var f= document.getElementById("gvSensinfo");
        for(var i=0; i<f.getElementsByTagName("input").length ;i++ )
        {
            if(f.getElementsByTagName("input").item(i).type == "text" )
            {
                shw8(f.getElementsByTagName("input").item(i).id,f,i);

            }  
        }  
            
    }
   
}
function shw8(id,obj,i)
{

     var total=$('#hdn_total').val();
    if(i==8)
    {
        if((document.getElementById(id).value)=="" || (document.getElementById(id).value) == null && i==8)
        {
                alert("Please Enter Pos1 Value");
                obj.getElementsByTagName("input").item(8).focus();
                return false;
        }
        else
        {
            
        return true;
        }
    }
}
function show_errr9()
{
    var total=$('#hdn_total').val();
   
    if(total>=0)
    {
        var f= document.getElementById("gvSensinfo");
        for(var i=0; i<f.getElementsByTagName("input").length ;i++ )
        {
            if(f.getElementsByTagName("input").item(i).type == "text" )
            {
                shw9(f.getElementsByTagName("input").item(i).id,f,i);

            }  
        }  
            
    }
   
}
function shw9(id,obj,i)
{

     var total=$('#hdn_total').val();
    if(i==9)
    {
        if((document.getElementById(id).value)=="" || (document.getElementById(id).value) == null && i==9)
        {
                alert("Please Enter Pos2 Value");
                obj.getElementsByTagName("input").item(9).focus();
                return false;
        }
        else
        {
            
        return true;
        }
    }
}
