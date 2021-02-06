//A17724Q
var yellowcountQ=0;
var yellowcountJ=0;
var yellowcountC=0;
var yellowcountN=0;
var yellowcountU=0;



function showcmmvalue(data)
{
  var values=document.getElementById(data).value;
  var res = values.toUpperCase();  
if(res =="OK" || res=="NOTOK" || res =="NOT OK" ||  res =="" ||res =="Q=OK" || res =="Q=NOTOK" ||res =="Q=NOT OK")
{
}
else{

alert("Enter valid value..! eg: OK (or) NOTOK");
document.getElementById(data).focus();
document.getElementById(data).value="";
}
}


function showrangevalues(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(67.623) || values < parseFloat(67.577))
    {
   
       document.getElementById(data).style.backgroundColor = "red";
       if(parseInt(yellowcountQ)!=0)
       {
        yellowcountQ=yellowcountQ-1;
       }
       else
       {
       }
        
    }
    else if(values >= parseFloat(67.615) && values <= parseFloat(67.623))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
       yellowcountQ=yellowcountQ+1;
        
    }
    else  if(values >= parseFloat(67.577) && values <= parseFloat(67.589))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
       yellowcountQ=yellowcountQ+1;
        
    }
     else if(values >= parseFloat(67.590) && values <= parseFloat(67.614))
    {
       document.getElementById(data).style.backgroundColor = "green";
       yellowcountQ=yellowcountQ+1;
        
    }
    
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    if(parseInt(yellowcountQ)>=3)
    {
       // alert("YELLOW");
    }
    
    
}
function showrangevalues1(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(75.023) || values < parseFloat(74.977))
    {
       document.getElementById(data).style.backgroundColor = "red";
       if(parseInt(yellowcountQ)!=0)
       {
        yellowcountQ=yellowcountQ-1;
       }
       else
       {
       }
        
    }
    else if(values >= parseFloat(75.015) && values <= parseFloat(75.023))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
       yellowcountQ=yellowcountQ+1;
        
    }
    else if(values >= parseFloat(74.977) && values <= parseFloat(74.989))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
       yellowcountQ=yellowcountQ+1;
        
    }
    else if(values >= parseFloat(74.990) && values <= parseFloat(75.014))
    {
       document.getElementById(data).style.backgroundColor = "green";
       yellowcountQ=yellowcountQ+1;
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
     if(parseInt(yellowcountQ)>=3)
    {
        //alert("YELLOW");
    }
    
}
function showrangevalues2(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(81.727) || values < parseFloat(81.673))
    {
       document.getElementById(data).style.backgroundColor = "red";
       if(parseInt(yellowcountQ)!=0)
       {
        yellowcountQ=yellowcountQ-1;
       }
       else
       {
       }
        
    }
    else if(values >= parseFloat(81.715) && values <= parseFloat(81.727))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
       yellowcountQ=yellowcountQ+1;
        
    }
   else  if(values >= parseFloat(81.673) && values <= parseFloat(81.689))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
       yellowcountQ=yellowcountQ+1;
        
    }
     else if(values >= parseFloat(81.690) && values <= parseFloat(81.714))
    {
       document.getElementById(data).style.backgroundColor = "green";
       yellowcountQ=yellowcountQ+1;
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
     if(parseInt(yellowcountQ)>=3)
    {
       // alert("YELLOW");
    }
    
}
function Roughness(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function Roughness1(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(3.2))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function Vernier1(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(68.50))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function Vernier2(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(75.90))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function Vernier3(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(82.60))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function GoNoGo(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(8.150))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function Verniercaliper1(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(71.100))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function Verniercaliper2(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(48.100))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function Roughnesstester(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function Roughnesstester1(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(6.3))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function Heightgauge(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(46.0))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function Vernier11(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(5.0))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function Vernier12(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(2.50))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function Vernier13(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(2.50))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
//==================================================================================================
//A22916J
function showrangevaluesJ(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(67.623) || values < parseFloat(67.577))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else if(values >= parseFloat(67.615) && values <= parseFloat(67.623))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
    else if(values >= parseFloat(67.577) && values <= parseFloat(67.589))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
     else if(values >= parseFloat(67.590) && values <= parseFloat(67.614))
    {
       document.getElementById(data).style.backgroundColor = "green";
        
    }
   
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesJ1(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(75.023) || values < parseFloat(74.977))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else if(values >= parseFloat(75.015) && values <= parseFloat(75.023))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
    else if(values >= parseFloat(74.977) && values <= parseFloat(74.989))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
     else if(values >= parseFloat(75.014) && values <= parseFloat(74.990))
    {
       document.getElementById(data).style.backgroundColor = "green";
        
    }
   
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesJ2(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(81.727) || values < parseFloat(81.673))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else  if(values >= parseFloat(81.715) && values <= parseFloat(81.727))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
    else  if(values >= parseFloat(81.673) && values <= parseFloat(81.689))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
     else if(values >= parseFloat(81.690) && values <= parseFloat(81.714))
    {
       document.getElementById(data).style.backgroundColor = "green";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function RoughnessJ(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessJ1(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(3.2))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VernierJ1(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(68.60))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VernierJ2(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(76))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VernierJ3(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(82.70))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function GoNoGoJ(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(8.150))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VerniercaliperJ1(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(71.100))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VerniercaliperJ2(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(48.100))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function GoNoGoJ1(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(6.100))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function Roughnesstesterj(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function Roughnesstesterj1(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(6.3))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function Heightgaugej(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(74.5))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function Vernierj11(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(2.0))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
//====================================================================================
//A32271C
function showrangevaluesC(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(67.623) || values < parseFloat(67.577))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else if(values >= parseFloat(67.615) && values <= parseFloat(67.623))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
    else if(values >= parseFloat(67.577) && values <= parseFloat(67.589))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
     else if(values >= parseFloat(67.590) && values <= parseFloat( 67.614))
    {
       document.getElementById(data).style.backgroundColor = "green";
       yellowcountQ=yellowcountQ+1;
        
    }
 
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesC3(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(71.423) || values < parseFloat(71.377))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else if(values >= parseFloat(71.415) && values <= parseFloat(71.423))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
    else if(values >= parseFloat(71.377) && values <= parseFloat(71.389))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
     else if(values >= parseFloat(71.390) && values <= parseFloat(71.414))
    {
       document.getElementById(data).style.backgroundColor = "green";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
  
}
function showrangevaluesC1(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(75.023) || values < parseFloat(74.977))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else if(values >= parseFloat(75.015) && values <= parseFloat(75.023))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
        
    }
    else if(values >= parseFloat(74.977) && values <= parseFloat(74.989))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
     else if(values >= parseFloat( 74.990) && values <= parseFloat(75.014))
    {
       document.getElementById(data).style.backgroundColor = "green";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
   
}
function showrangevaluesC2(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(81.727) || values < parseFloat(81.673))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else if(values >= parseFloat(81.715) && values <= parseFloat(81.727))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
    else if(values >= parseFloat(81.673) && values <= parseFloat(81.689))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
      else if(values >= parseFloat( 81.690) && values <= parseFloat(81.714))
    {
       document.getElementById(data).style.backgroundColor = "green";
        
    }
   
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}

function RoughnessC(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessC1(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(3.2))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VernierC1(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(68.40))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VernierC2(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(72.20))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VernierC3(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(75.80))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VernierC4(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(82.50))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function GoNoGoC(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(8.150))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VerniercaliperC1(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(71.100))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VerniercaliperC2(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(48.100))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function GoNoGoC1(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(6.100))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnesstesterC(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function RoughnesstesterC1(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(6.3))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function HeightgaugeC(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(74.0))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function VernierC11(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.0))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function VernierC12(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(72.25))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function VernierC13(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(74.7))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
//======================================================================================================
//A44908N
function showrangevaluesN(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(87.167) || values < parseFloat(87.113))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else if(values >= parseFloat(87.157) && values <= parseFloat(87.167))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
    else if(values >= parseFloat(87.113) && values <= parseFloat(87.129))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
    else if(values >= parseFloat(87.130) && values <= parseFloat(87.156))
    {
       document.getElementById(data).style.backgroundColor = "green";
        
    }
  
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesN1(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(96.527) || values < parseFloat(96.473))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
     else if(values >= parseFloat(96.517) && values <= parseFloat(96.527))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
    else if(values >= parseFloat(96.473) && values <= parseFloat(96.489))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
     else if(values >= parseFloat(96.490) && values <= parseFloat( 96.516))
    {
       document.getElementById(data).style.backgroundColor = "green";
        
    }

    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesN2(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(105.027) || values < parseFloat(104.973))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
     else if(values >= parseFloat(105.016) && values <= parseFloat(105.027))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
    else if(values >= parseFloat(104.973) && values <= parseFloat(104.989))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
     else if(values >= parseFloat(104.990) && values <= parseFloat(105.015))
    {
       document.getElementById(data).style.backgroundColor = "green";
        
    }
   
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function RoughnessN(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessN1(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(3.2))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VernierN1(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(88.20))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VernierN2(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(97.50))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VernierN3(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(106.0))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function GoNoGoN(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(10.15))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VerniercaliperN1(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(90.60))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VerniercaliperN2(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(61.60))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnesstesterN(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function RoughnesstesterN1(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(6.3))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 

function VernierN11(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.5))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function VernierN12(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(104.25))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function VernierN13(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(2.50))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function VernierN14(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(14.25))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function VernierN15(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(9.360))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function VerniercaliperN3(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(70.30))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VerniercaliperN4(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(71.75))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VerniercaliperN5(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(8.25))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
//=========================================================================================
//A44983u
function showrangevaluesU(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(87.167) || values < parseFloat(87.113))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
   else if(values >= parseFloat(87.157) && values <= parseFloat(87.167))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
   else if(values >= parseFloat(87.113) && values <= parseFloat(87.129))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
     else if(values >= parseFloat(87.130) && values <= parseFloat(87.156))
    {
       document.getElementById(data).style.backgroundColor = "green";
        
    }

    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function showrangevaluesU3(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(91.977) || values < parseFloat(91.923))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
     else if(values >= parseFloat(91.967) && values <= parseFloat(91.977))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
   else if(values >= parseFloat(91.923) && values <= parseFloat(91.939))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
     else if(values >= parseFloat(91.940) && values <= parseFloat( 91.966))
    {
       document.getElementById(data).style.backgroundColor = "green";
        
    }
   
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesU1(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(96.527) || values < parseFloat(96.473))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
     else if(values >= parseFloat(96.517) && values <= parseFloat(96.527))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
   else if(values >= parseFloat(96.473) && values <= parseFloat(96.489))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
     else if(values >= parseFloat(96.490) && values <= parseFloat( 96.516))
    {
       document.getElementById(data).style.backgroundColor = "green";
        
    }
    
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesU2(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(105.027) || values < parseFloat(104.973))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
     else if(values >= parseFloat(105.016) && values <= parseFloat(105.027))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
   else if(values >= parseFloat(104.973) && values <= parseFloat(104.989))
    {
       document.getElementById(data).style.backgroundColor = "yellow";
        
    }
     else if(values >= parseFloat(104.990) && values <= parseFloat( 105.015))
    {
       document.getElementById(data).style.backgroundColor = "green";
        
    }
   
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}

function RoughnessU(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessU1(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(3.2))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VernierU1(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(88.20))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VernierU2(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(93.00))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VernierU3(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(97.50))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VernierU4(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(106.00))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function GoNoGoU(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(10.15))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VerniercaliperU1(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(90.60))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function VerniercaliperU2(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(61.60))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function GoNoGoU1(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(6.100))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnesstesterU(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
function RoughnesstesterU1(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(6.3))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
} 
//======================================================================================================
//A22916J  Polishing
function showrangevaluesPJ(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(81.727) || values < parseFloat(81.673))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesPJ1(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(75.023) || values < parseFloat(74.977))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesPJ2(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(67.623) || values < parseFloat(67.577))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function RoughnessPJ(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessPJ1(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(7.2))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessPJ2(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessPJ3(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(7.2))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessPJ4(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessPJ5(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(7.2))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
//====================================================================================================
//A17724Q  Polishing
function showrangevaluesPQ(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(81.727) || values < parseFloat(81.673))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesPQ1(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(75.023) || values < parseFloat(74.977))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesPQ2(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(67.623) || values < parseFloat(67.577))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function RoughnessPQ(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessPQ1(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(7.2))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessPQ2(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessPQ3(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(7.2))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessPQ4(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessPQ5(data)
{
     var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(7.2))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
//====================================================================================
//A32271C
function showrangevaluesPC(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(81.727) || values < parseFloat(81.673))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesPC3(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(75.023) || values < parseFloat(74.977))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesPC1(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(71.423) || values < parseFloat(71.377))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesPC2(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(67.623) || values < parseFloat(67.577))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function RoughnessPC(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessPC1(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(7.2))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
//============================================================================
// A44908N polishing

function showrangevaluesPN(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(87.167) || values < parseFloat(87.113))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}

function showrangevaluesPN1(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(96.527) || values < parseFloat(96.473))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesPN2(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(105.027) || values < parseFloat(104.973))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function RoughnessPN(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessPN1(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(7.2))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
//=========================================================================
//A44983U
function showrangevaluesPU(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(87.167) || values < parseFloat(87.113))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesPU3(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(91.977) || values < parseFloat(91.923))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesPU1(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(96.527) || values < parseFloat(96.473))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function showrangevaluesPU2(data)
{

    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(105.027) || values < parseFloat(104.973))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
    
}
function RoughnessPU(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(1.6))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}
function RoughnessPU1(data)
{
    var values=document.getElementById(data).value;
    values=parseFloat(values);
    if(values > parseFloat(7.2))
    {
       document.getElementById(data).style.backgroundColor = "red";
        
    }
    else
    {
         document.getElementById(data).style.backgroundColor = "#f7dff0";
    }
}