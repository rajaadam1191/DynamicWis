var rmax=[];
var rmin=[];
var ymean=[];
var other=[];
var excel=0;
function getBrowserHeight() 
{
    var intH = 0;
    var intW = 0;
    if(typeof window.innerWidth == 'number' ) {
    intH = window.innerHeight;
    intW = window.innerWidth;
    }
    else if(document.documentElement && (document.documentElement.clientWidth || document.documentElement.clientHeight)) {
    intH = document.documentElement.clientHeight;
    intW = document.documentElement.clientWidth;
    }
    else if(document.body && (document.body.clientWidth || document.body.clientHeight)) {
    intH = document.body.clientHeight;
    intW = document.body.clientWidth;
    }
    return { width: parseInt(intW), height: parseInt(intH) };
}
function setLayerPosition() {
    var shadow = document.getElementById('shadow');
    var question = document.getElementById('question');


    var bws = getBrowserHeight();
    shadow.style.width = bws.width + 'px';
    shadow.style.height = bws.height + 'px';

    question.style.left = parseInt((bws.width - 400) / 2)+ 'px';
    question.style.top = parseInt((bws.height - 200) / 2)+ 'px';

    shadow = null;
    question = null;
}

 
function showLayer() {
    setLayerPosition();
    var shadow = document.getElementById('shadow');
    var question = document.getElementById('question');
    // var popdiv = document.getElementById('popdiv');
    shadow.style.display = 'block';
    question.style.display = 'block';
     
    shadow = null;
    question = null;
}
 
function hideLayer() {
    var shadow = document.getElementById('shadow');
    var question = document.getElementById('question');
     
    shadow.style.display = 'none';
    question.style.display = 'none';
     
    shadow = null;
    question = null;
}




var MaxMin=[];
var tid=0;
function getpart()
{
        $.ajax({
                url:"../Master/Default.aspx/Get_prtno",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    $("select[id$='dy_partno']").get(0).options.length = 0;
                    $("select[id$='dy_partno']").get(0).options[0] = new Option("--- Select Part Number ---", "0");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='dy_partno']").get(0).options[$("select[id$='dy_partno']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                        
                    }
                    var p=$("input[id$='hdn_part']").val();
                    if(p!="")
                    {
                        $("select[id$='dy_partno']").val(p);
                    }
                    part=null;
                    comma=null;
                    
              },
                error:function()
                {}
              });
  }
function getpart1()
{
        $.ajax({
                url:"../Master/Default.aspx/Get_prtno",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    $("select[id$='dy_partno1']").get(0).options.length = 0;
                    $("select[id$='dy_partno1']").get(0).options[0] = new Option("--- Select Part Number ---", "0");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='dy_partno1']").get(0).options[$("select[id$='dy_partno1']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                        
                    }
                  
                    part=null;
                    comma=null;
                    
              },
                error:function()
                {}
              });
  }

$(function()
{
    $('#btn_QSView').click(function()
    {
        var res=validateQS();
       
        if(res==true)
        {
            window.top.location.href="../DYNSheets/AdminQulitySheet.aspx?partno="+$("input[id$='hdn_part']").val()+"&operation="+$("input[id$='hdn_operation']").val()+"&unit=MBU&cell="+$("input[id$='hdn_cell']").val()+"&mach="+$("input[id$='hdn_mach']").val()+"&shift="+$("input[id$='hdn_shift']").val()+"&date="+$("input[id$='txt_prod_fromdate']").val()+"&date="+$("input[id$='hdn_operator']").val()+"";
        }
    });
});
function validateQS()
{
    if(!valprodpart())return false
    if(!valprodoper())return false
    if(!valprodcell())return false
    if(!valprodmach())return false
    if(!valprodshift())return false
    if(!valprodopertor())return false
    return true;
}

function valprodcell()
{
     var cell=$("select[id$='ddl_prod_cell']").val();
     if(cell=="" || cell==null || cell=="0")
     {
        alert("Select Cell");
        return false;
     }
     else
     {
     $("input[id$='hdn_cell']").val(cell);
       return true;
     }
}
function valprodmach()
{
     var mach=$("select[id$='Slct_prod_machine']").val();
     if(mach=="" || mach==null || mach=="0")
     {
        alert("Select Machine");
        return false;
     }
     else
     {
     $("input[id$='hdn_mach']").val(mach);
       return true;
     }
}
function valprodpart()
{
     var part=$("select[id$='ddl_prod_partno']").val();
     if(part=="" || part==null || part=="0")
     {
        alert("Select Part Number");
        return false;
     }
     else
     {
     $("input[id$='hdn_part']").val(part);
       return true;
     }
}
function valprodoper()
{
     var oper=$("select[id$='ddl_prod_operation']").val();
     if(oper=="" || oper==null || oper=="0")
     {
        alert("Select Operation");
        return false;
     }
     else
     {
     $("input[id$='hdn_operation']").val(oper);
       return true;
     }
}

function valprodshift()
{
     var shift=$("select[id$='ddl_prod_shift']").val();
     if(shift=="" || shift==null || shift=="0")
     {
        alert("Select Shift");
        return false;
     }
     else
     {
     $("input[id$='hdn_shift']").val(shift);
       return true;
     }
}
function valprodopertor()
{
     var oper=$("select[id$='Slct_prod_operator']").val();
     if(oper=="" || oper==null || oper=="0")
     {
        alert("Select Opeator");
        return false;
     }
     else
     {
     $("input[id$='hdn_operator']").val(oper);
       return true;
     }
}
function GetOperation()
{
var comma=null;
var part=[];
$.ajax({
        url:"../Master/Default.aspx/Get_prtprocess",
        data:"{}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            $("select[id$='ddl_prod_operation']").get(0).options.length = 0;
            $("select[id$='ddl_prod_operation']").get(0).options[0] = new Option("--- Select Operation ---", "0");
            part=msg.d;
            comma=part.split(",");
            for(var count=0;count<comma.length;count++)
            {
                if(comma[count]=="")
                {
                }
                else
                {
                    if(comma[count]=="OP1")
                    {
                        $("select[id$='ddl_prod_operation']").get(0).options[$("select[id$='ddl_prod_operation']").get(0).options.length] = new Option(comma[count], "1");                            
                    }
                    else if(comma[count]=="OP2")
                    {
                        $("select[id$='ddl_prod_operation']").get(0).options[$("select[id$='ddl_prod_operation']").get(0).options.length] = new Option(comma[count], "2");
                    }
                    else
                    {
                        $("select[id$='ddl_prod_operation']").get(0).options[$("select[id$='ddl_prod_operation']").get(0).options.length] = new Option(comma[count], comma[count]);
                    }
                }
            }
            part=null;
            comma=null;
           
          },
            error:function()
            {}
    });
              
}

function getprodmachine()
{
var dept=$("select[id$='ddl_prod_cell']").val();
$.ajax({
        url:"../Master/Default.aspx/getmachinename",
        data:"{'dept':'"+dept+"'}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
        
            $("select[id$='Slct_prod_machine']").get(0).options.length = 0;
            $("select[id$='Slct_prod_machine']").get(0).options[0] = new Option("--- Select Machine ---", "0");
            part=msg.d;
            comma=part.split(",");
            for(var count=0;count<comma.length;count++)
            {
                if(comma[count]=="")
                {
                }
                else
                {
                    $("select[id$='Slct_prod_machine']").get(0).options[$("select[id$='Slct_prod_machine']").get(0).options.length] = new Option(comma[count], comma[count]);
                }
            }
            
            var M=$("input[id$='hdn_mach']").val();
            if(M!="")
            {
                $("select[id$='Slct_prod_machine']").val(M);
            }
            
            part=null;
            comma=null;
            
      },
        error:function()
        {}
      });
}
function getProdpart()
{
        $.ajax({
                url:"../Master/Default.aspx/Get_prtno",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
//                    $("select[id$='ddl_partnosrch']").get(0).options.length = 0;
//                    $("select[id$='ddl_partnosrch']").get(0).options[0] = new Option("--- Select Part Number ---", "0");
                    
                    $("select[id$='ddl_prod_partno']").get(0).options.length = 0;
                    $("select[id$='ddl_prod_partno']").get(0).options[0] = new Option("--- Select Part Number ---", "0");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='ddl_prod_partno']").get(0).options[$("select[id$='ddl_prod_partno']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                        
                    }
                    var p=$("input[id$='hdn_part']").val();
                    if(p!="")
                    {
                        $("select[id$='ddl_prod_partno']").val(p);
                    }
                    part=null;
                    comma=null;
                    GetProdProcess();
              },
                error:function()
                {}
              });
}


function GetProdProcess()
{
var comma=null;
var part=[];
$.ajax({
        url:"../Master/Default.aspx/Get_prtprocess",
        data:"{}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            $("select[id$='ddl_prod_operation']").get(0).options.length = 0;
            $("select[id$='ddl_prod_operation']").get(0).options[0] = new Option("--- Select Operation ---", "0");
            part=msg.d;
            comma=part.split(",");
            for(var count=0;count<comma.length;count++)
            {
                if(comma[count]=="")
                {
                }
                else
                {
                    if(comma[count]=="OP1")
                    {
                        $("select[id$='ddl_prod_operation']").get(0).options[$("select[id$='ddl_prod_operation']").get(0).options.length] = new Option(comma[count], "1");                            
                    }
                    else if(comma[count]=="OP2")
                    {
                        $("select[id$='ddl_prod_operation']").get(0).options[$("select[id$='ddl_prod_operation']").get(0).options.length] = new Option(comma[count], "2");
                    }
                    else
                    {
                        $("select[id$='ddl_prod_operation']").get(0).options[$("select[id$='ddl_prod_operation']").get(0).options.length] = new Option(comma[count], comma[count]);
                    }
                }
            }
            var p=$("input[id$='hdn_oper']").val();
            if(p!="")
            {
                $("select[id$='ddl_prod_operation']").val(p);
            }
            part=null;
            comma=null;
            getprodcell();
          },
            error:function()
            {}
    });
              
}

function getprodcell()
{
var unt="MBU";
$.ajax({
        url:"../Master/Default.aspx/getdepartment",
        data:"{'unit':'"+unt+"'}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            $("select[id$='ddl_prod_cell']").get(0).options.length = 0;
            $("select[id$='ddl_prod_cell']").get(0).options[0] = new Option("--- Select Cell ---", "0");
            part=msg.d;
            comma=part.split(",");
           
            for(var count=0;count<comma.length;count++)
            {
                if(comma[count]=="")
                {
                }
                else
                {
                    $("select[id$='ddl_prod_cell']").get(0).options[$("select[id$='ddl_prod_cell']").get(0).options.length] = new Option(comma[count], comma[count]);
                }
            }
            part=null;
            comma=null;
      },
        error:function()
        {}
      });
}

function getprodoper()
{
var part=$("select[id$='ddl_prod_partno']").val();
var opr=$("select[id$='ddl_prod_operation']").val();
var cell=$("select[id$='ddl_prod_cell']").val();
var mach=$("select[id$='Slct_prod_machine']").val();
var shift=$("select[id$='ddl_prod_shift']").val();
var date=$("input[id$='txt_prod_fromdate']").val();
$.ajax({
        url:"../Master/Default.aspx/getProdOper",
        data:"{'Partno':'"+part+"','Operation':'"+opr+"','Cell':'"+cell+"','Machine':'"+mach+"','Shift':'"+shift+"','Date':'"+date+"'}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            $("select[id$='Slct_prod_operator']").get(0).options.length = 0;
            $("select[id$='Slct_prod_operator']").get(0).options[0] = new Option("--- Select Opertor ---", "0");
            part=msg.d;
            comma=part.split(",");
           
            for(var count=0;count<comma.length;count++)
            {
                if(comma[count]=="")
                {
                }
                else
                {
                    $("select[id$='Slct_prod_operator']").get(0).options[$("select[id$='Slct_prod_operator']").get(0).options.length] = new Option(comma[count], comma[count]);
                }
            }
            part=null;
            comma=null;
      },
        error:function()
        {}
      });
}

function getprodadminoper()
{
var part=$("input[id$='hdn_partno1']").val();
var opr=$("input[id$='hdn_operation']").val();
var cell=$("input[id$='hdn_cell']").val();
var mach=$("select[id$='ddl_adminmach']").val();
var shift=$("select[id$='ddl_adminshift']").val();
var date=$("input[id$='txt_date']").val();
$.ajax({
        url:"../Master/Default.aspx/getProdOper",
        data:"{'Partno':'"+part+"','Operation':'"+opr+"','Cell':'"+cell+"','Machine':'"+mach+"','Shift':'"+shift+"','Date':'"+date+"'}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            $("select[id$='ddl_adminoperator']").get(0).options.length = 0;
            $("select[id$='ddl_adminoperator']").get(0).options[0] = new Option("--- Select Opertor ---", "0");
            part=msg.d;
            comma=part.split(",");
           
            for(var count=0;count<comma.length;count++)
            {
                if(comma[count]=="")
                {
                }
                else
                {
                    $("select[id$='ddl_adminoperator']").get(0).options[$("select[id$='ddl_adminoperator']").get(0).options.length] = new Option(comma[count], comma[count]);
                }
            }
            part=null;
            comma=null;
      },
        error:function()
        {}
      });
}

function getcell()
{
        var unt=$("select[id$='dy_unit']").val();
        $.ajax({
                url:"../Master/Default.aspx/getdepartment",
                data:"{'unit':'"+unt+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    $("select[id$='dy_cell']").get(0).options.length = 0;
                    $("select[id$='dy_cell']").get(0).options[0] = new Option("--- Select Cell ---", "0");
                    part=msg.d;
                    comma=part.split(",");
                   
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='dy_cell']").get(0).options[$("select[id$='dy_cell']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    part=null;
                    comma=null;
                    
              },
                error:function()
                {}
              });
}

 function changecase()
 {
    var c=$("input[id$='dy_intrument']").val()
    $("input[id$='dy_intrument']").val(c.toUpperCase());
 }
 function changecase1()
 {
    var c=$("input[id$='txt_shortname']").val()
    $("input[id$='txt_shortname']").val(c.toUpperCase());
 }
 function changecase2()
 {
    var c=$("input[id$='Txt_headername']").val()
    $("input[id$='Txt_headername']").val(c.toUpperCase());
 }
 function validatedyn()
 {
    if(!partno())return false
    if(!d_operation())return false
    if(!unit())return false
    if(!cell())return false
    if(!inst())return false
    if(!instshort())return false
    if(!instco())return false
    if(!range())return false
  
 }
 function partno()
 {
    var part= $("select[id$='dy_partno']").val();
    if(part=="0")
    { 
       alert('Select Part No');
        return false;
    }
    else
    {
        $("input[id$='hdn_part']").val(part);
       
        return true;
    }
    
 }
 function d_operation()
 {
    var opr= $("select[id$='dy_operation']").val();
    if(opr == "0")
    {
      alert('Select Operation');
     return false;
      
       
    }
    else
    {
        return true;
    }
    
 }
 function unit()
 {
    var unit=$("select[id$='dy_unit']").val();
    if(unit=="0")
    {
        alert('Select Unit');
        return false;
    }
    else
    {
        
        return true;
    }
    
 }
 function cell()
 {
    var cell=$("select[id$='dy_cell']").val();
    if(cell=="0")
    {
        alert('Select Cell');
        return false;
    }
    else
    {
        $("input[id$='hdncell']").val(cell);
        return true;
    }
    
 }
 function inst()
 {
    var inst=$("input[id$='dy_intrument']").val();
    if(inst=="" || inst==null)
    {
       alert('Enter Instrument Name');
        return false;
    }
    else
    {
        return true;
    }
    
 }
 function instshort()
 {
    var short1=$("input[id$='txt_shortname']").val();
    if(short1=="" || short1==null)
    {
       alert('Enter Instrument Short Name');
        return false;
    }
    else
    {
        return true;
    }
    
 }
 function instco()
 {
    var cou=$("input[id$='dy_instruvalues']").val();
    if(cou=="" || cou==null)
    {
        alert('Enter Instrument Value');
        return false;
    }
    else
    {
        return true;
    }
    
 }
  function range()
 {
    var range=$("select[id$='dy_ranges']").val();
    if(range=="0")
    {
         alert('Enter Instrument Ranges');
        return false;
    }
    else
    {
        return true;
    }
    
 }
 $(function()
 {
    $('#btn_dyupdate').click(function()
    {
        var id= $("input[id$='hdn_dyid']").val();
        var part=$("select[id$='dy_partno']").val();
        var oper=$("select[id$='dy_operation']").val();
        var unit=$("select[id$='dy_unit']").val();
        var cell=$("select[id$='dy_cell']").val();
        var instr=$("input[id$='dy_intrument']").val();
        var instr_v=$("input[id$='dy_instruvalues']").val();
        var instr_r=$("select[id$='dy_ranges']").val();
        var short1=$("input[id$='txt_shortname']").val();
        var cells=$("input[id$='txt_noofcells']").val();
        var header=$("input[id$='Txt_headername']").val();
        $.ajax({
                url:"../Master/Default.aspx/updatedynmaster",
                data:"{'ID':'"+id+"','Part':'"+part+"','Opertaion':'"+oper+"','Unit':'"+unit+"','Cell':'"+cell+"','Instru':'"+instr+"','InstV':'"+instr_v+"','InstR':'"+instr_r+"','Short':'"+short1+"','Cells':'"+cells+"','Header':'"+header+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        $("input[id$='hdn_dyid']").val('');
                        $("input[id$='hdn_part']").val('');
                        getpart();
                        $("select[id$='dy_operation']").val('0');
                        $("select[id$='dy_unit']").val('0');
                        $("select[id$='dy_cell']").val('0');
                        $("input[id$='dy_intrument']").val('');
                        $("input[id$='dy_instruvalues']").val('');
                        $("select[id$='dy_ranges']").val('');
                        $("div[id$='div_save']").show();
                        $("div[id$='div_updatge']").hide();
                        var url='../Master/DYNMaster.aspx';
                        window.top.location.href=url;
                    }
                    else
                    {
                    }
                },
                error:function()
                {}
              }); 
    });
 });
 function edit(id)
 {
 $("div[id$='div_save']").hide();
 $("div[id$='div_updatge']").show();
 $("input[id$='hdn_dyid']").val(id);

        $.ajax({
                url:"../Master/Default.aspx/editdynmaster",
                data:"{'id':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
               
                    for(var i=0;i<msg.d.length;i++)
                    {
                        $("input[id$='hdn_part']").val(msg.d[i].partno);
                        getpart();
                        $("select[id$='dy_operation']").val(msg.d[i].operation);
                        $("select[id$='dy_unit']").val(msg.d[i].unit);
                        $("select[id$='dy_cell']").val(msg.d[i].cell);
                        $("input[id$='dy_intrument']").val(msg.d[i].instrument);
                        $("input[id$='dy_instruvalues']").val(msg.d[i].inst_values);
                    //  $("input[id$='dy_instruvalues']").attr('disabled',true);
                        $("select[id$='dy_ranges']").val(msg.d[i].inst_ranges);
                        $("input[id$='txt_shortname']").val(msg.d[i].shortname);
                        $("input[id$='Txt_headername']").val(msg.d[i].headername);
                    }    
                },
                error:function()
                {}
              });  
 }
 function _delete(id)
 {
   var res=window.confirm('Are You Want to delte this Instrument');
   if(res==true)
   {
                $.ajax({
                        url:"../Master/Default.aspx/deletedynmaster",
                        data:"{'ID':'"+id+"'}",
                        type:"POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(msg)
                        {
                            if(msg.d=="S")
                            {
                                var url='../Master/DYNMaster.aspx';
                                window.top.location.href=url;
                            }
                            else
                            {
                            }   
                        },
                        error:function()
                        {}
              });
   }
   else
   {
   }
 }
 $(function()
 {
    $('#btn_view').click(function()
    {
        var res=val_values();
        var _count=0;
        var _count1=0;
        if(res==true)
        {
             var part=$("select[id$='dy_partno1']").val();
             var opr=$("select[id$='dy_operation1']").val();
             var unit=$("select[id$='dy_unit1']").val();
             var cell=$("select[id$='dy_cell1']").val();
             $.ajax({
                    url:"../Master/Default.aspx/getinstruments",
                    data:"{'Partno':'"+part+"','Opertaion':'"+opr+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
                    type:"POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg)
                    {
                        part=msg.d;
                        comma=part.split(",");
                     
                      _count=comma.length-1;
                       var  tbl='<table><TR><TD>';
                        for(var count=0;count<comma.length;count++)
                        {
                            if(comma[count]=="")
                            {
                            }
                            else
                            {
                                        var part1=$("select[id$='dy_partno1']").val();
                                        var opr1=$("select[id$='dy_operation1']").val();
                                        var unit1=$("select[id$='dy_unit1']").val();
                                        var cell1=$("select[id$='dy_cell1']").val();
                                        var instru=comma[count];
                                        $.ajax({
                                        url:"../Master/Default.aspx/getinstrumentsvalues",
                                        data:"{'Instruments':'"+instru+"','Partno':'"+part1+"','Opertaion':'"+opr1+"','Unit':'"+unit1+"','Cell':'"+cell1+"'}",
                                        type:"POST",
                                        contentType: "application/json; charset=utf-8",
                                        dataType: "json",
                                        success: function(msg)
                                        {
                                          _count1+=1;
                                           for(var i=0;i<1;i++)
                                           {
                                                var newStr = msg.d[i].Instrument.replace(/\s+/g, '');
                                                var r_count=0;
                                                var count=msg.d[i].Count;
                                                var rcount=msg.d[i].Count1;
                                                var c_count=parseInt(msg.d[i].Count1)-parseInt(msg.d[i].Count);
                                                if(parseInt(c_count)>=0)
                                                {
                                                    tbl+='<table>';
                                                    tbl+='<tr><td><div align="center" style=""><span class="dy_hspan"  id="spn_'+msg.d[i].Instrument+'">'+msg.d[i].Instrument+'</span></div></td></tr>';
                                                    tbl+='<div><table id="tbl_'+msg.d[i].id+'">';
                                                    tbl+='<tr><td><span >S.No</span></td><td></td><td class="dy_td"><span>Dimensions</span></td><td class="dy_td"><span>Upper Specification</span></td><td class="dy_td"><span>Mean Specification</span></td><td class="dy_td"><span>Lower Specification</span></td><td class="dy_td"><span>Frequency</span></td></tr>';
                                                    for(var j=0;j<parseInt(count);j++)
                                                    { 
                                                        if(msg.d[j].Upper!="")
                                                       {
                                                           r_count+=1;
                                                           tbl+='<tr><td><span>'+r_count+'</span></td><td>:</td><td><input type="text" id="txt_dimension_'+msg.d[i].id+''+j+'" class="dy_text" value='+msg.d[j].Dimession+'></td><td><input type="text" id="txt_max_'+msg.d[i].id+''+j+'" class="dy_text" value='+msg.d[j].Upper+'></td><td><input type="text" id="txt_mean_'+msg.d[i].id+''+j+'"  class="dy_text" value='+msg.d[j].Mean+'></td><td><input type="text" id="txt_min_'+msg.d[i].id+''+j+'"  class="dy_text" value='+msg.d[j].Lower+'></td><td ><input class="dy_text" readonly="readonly" type="text" id="txt_range_'+msg.d[i].id+''+j+'" value='+msg.d[j].Range+' /></td><td style="display:none;"><input class="dy_text" readonly="readonly" type="text" id="txt_id_'+msg.d[i].id+''+j+'" value='+msg.d[j].id1+' /></td></tr>'; 
                                                       }
                                                       
                                                    }
                                                    if(c_count>0)
                                                    {
                                                         for(var k=j;k<parseInt(rcount);k++)
                                                        { 
                                                               r_count+=1;
                                                               tbl+='<tr><td><span>'+r_count+'</span></td><td>:</td><td><input type="text" id="txt_dimension_'+msg.d[i].id+''+k+'" class="dy_text"/></td><td><input type="text" id="txt_max_'+msg.d[i].id+''+k+'" class="dy_text"/></td><td><input type="text" id="txt_mean_'+msg.d[i].id+''+k+'"  class="dy_text"/></td><td><input type="text" id="txt_min_'+msg.d[i].id+''+k+'"  class="dy_text"/></td><td ><input class="dy_text" readonly="readonly" type="text" id="txt_range_'+msg.d[i].id+''+k+'" value='+msg.d[i].Range+' /></td><td style="display:none;"><input class="dy_text" readonly="readonly" type="text" id="txt_id_'+msg.d[i].id+''+k+'" value="0" /></td></tr>'; 
                                                        }
                                                    }
                                                    tbl+='</table></div></td></tr></table>'; 
                                                }
                                                else
                                                {
                                                    tbl+='<table>';
                                                    tbl+='<tr><td><div align="center" style=""><span class="dy_hspan"  id="spn_'+msg.d[i].Instrument+'">'+msg.d[i].Instrument+'</span></div></td></tr>';
                                                    tbl+='<div><table id="tbl_'+msg.d[i].id+'">';
                                                    tbl+='<tr><td><span >S.No</span></td><td></td><td class="dy_td"><span>Dimensions</span></td><td class="dy_td"><span>Upper Specification</span></td><td class="dy_td"><span>Mean Specification</span></td><td class="dy_td"><span>Lower Specification</span></td><td class="dy_td"><span>Frequency</span></td></tr>';
                                                    for(var j=0;j<parseInt(count);j++)
                                                    { 
                                                           r_count+=1;
                                                           tbl+='<tr><td><span>'+r_count+'</span></td><td>:</td><td><input type="text" id="txt_dimension_'+msg.d[i].id+''+j+'" class="dy_text" /></td><td><input type="text" id="txt_max_'+msg.d[i].id+''+j+'" class="dy_text" /></td><td><input type="text" id="txt_mean_'+msg.d[i].id+''+j+'"  class="dy_text" /></td><td><input type="text" id="txt_min_'+msg.d[i].id+''+j+'"  class="dy_text" /></td><td ><input class="dy_text" readonly="readonly" type="text" id="txt_range_'+msg.d[i].id+''+j+'" value='+msg.d[i].Range+' /></td><td style="display:none;"><input class="dy_text" readonly="readonly" type="text" id="txt_id_'+msg.d[i].id+''+j+'" value="0" /></td></tr>'; 
                                                    }
                                                    tbl+='</table></div></td></tr></table>'; 
                                                }
                                           }
                                            
                                            tbl+='</TD></TR></table>';
                                            $("div[id$='div_dynvalues']").html(tbl); 
                                            $("div[id$='div_save']").show(); 
                                              
                                        },
                                        error:function()
                                        {}
                                      });
                            }
                            
                        }
                    
                       
                    },
                    error:function()
                    {}
              });
        }
        else
        {
        }
    });
 });
 function val_values()
 {
    if(!va_par())return false
    if(!va_op())return false
    if(!va_un())return false
    if(!va_cell())return false
    return true;
 }
function va_par()
{
    
    var part=$("select[id$='dy_partno1']").val();
    if(part=="0")
    {
        $("span[id$='dy_spn_error']").text('Select Part No');
        return false;
    }
    else
    {
        $("span[id$='dy_spn_error']").text('');
        return true;
    }
    
}
function va_op()
{
    
    var opr=$("select[id$='dy_operation1']").val();
    if(opr=="0")
    {
        $("span[id$='dy_spn_error']").text('Select Operation');
        return false;
    }
    else
    {
        $("span[id$='dy_spn_error']").text('');
        return true;
    }
    
}
function va_un()
{
    
    var unit=$("select[id$='dy_unit1']").val();
    if(unit=="0")
    {
        $("span[id$='dy_spn_error']").text('Select Unit');
        return false;
    }
    else
    {
        $("span[id$='dy_spn_error']").text('');
        return true;
    }
    
}
function va_cell()
{
    
    var cell=$("select[id$='dy_cell1']").val();
    if(cell=="0")
    {
        $("span[id$='dy_spn_error']").text('Select Cell');
        return false;
    }
    else
    {
        $("span[id$='dy_spn_error']").text('');
        return true;
    }
    
}
 
 
 $(function()
 {
    $('#btn_save').click(function()
    {
   
            var part=$("select[id$='dy_partno1']").val();
            var opr=$("select[id$='dy_operation1']").val();
            var unit=$("select[id$='dy_unit1']").val();
            var cell=$("select[id$='dy_cell1']").val();
             $.ajax({
                    url:"../Master/Default.aspx/getinstruments",
                    data:"{'Partno':'"+part+"','Opertaion':'"+opr+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
                    type:"POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg)
                    {
                        part=msg.d;
                        comma=part.split(",");
                        var flag='0';
                        for(var count=0;count<comma.length;count++)
                        {
                            if(comma[count]=="")
                            {
                            }
                            else
                            {
                                var newStr = comma[count];//comma[count].replace(/\s+/g, '');
                                var table = document.getElementById("tbl_"+newStr+"");
                                var tblength=table.rows.length-1;
                                for(var k=0;k<tblength;k++)
                                {
                                         flag=parseInt(flag)+1;
                                        var instru=comma[count];
                                        var dim=$('#txt_dimension_'+newStr+''+k+'').val();
                                        var max=$('#txt_max_'+newStr+''+k+'').val();
                                        var mean=$('#txt_mean_'+newStr+''+k+'').val();
                                        var min=$('#txt_min_'+newStr+''+k+'').val();
                                        var ranng=$('#txt_range_'+newStr+''+k+'').val();
                                        var id=$('#txt_id_'+newStr+''+k+'').val();
                                        var part=$("select[id$='dy_partno1']").val();
                                        var opr=$("select[id$='dy_operation1']").val();
                                        var unit=$("select[id$='dy_unit1']").val();
                                        var cell=$("select[id$='dy_cell1']").val();
                                         $.ajax({
                                                url:"../Master/Default.aspx/SaveDYNValues",
                                                data:"{'Partno':'"+part+"','Opertaion':'"+opr+"','Unit':'"+unit+"','Cell':'"+cell+"','Dim':'"+dim+"','Max':'"+max+"','Mean':'"+mean+"','Min':'"+min+"','Range':'"+ranng+"','Instrument':'"+instru+"','ID':'"+id+"','Flag':'"+flag+"'}",
                                                type:"POST",
                                                contentType: "application/json; charset=utf-8",
                                                dataType: "json",
                                                success: function(msg)
                                                {
                                                
                                                },
                                                 error:function()
                                                {}
                                              });
                                
                                }
                            
                            }
                            
                        }
                         flag='0';
                         alert('Saved Sussfully');
                         var part=$("select[id$='dy_partno1']").val();
                         var opr=$("select[id$='dy_operation1']").val();
                         var unit=$("select[id$='dy_unit1']").val();
                         var cell=$("select[id$='dy_cell1']").val();
                         $.ajax({
                                    url:"../Master/Default.aspx/CreateTable",
                                    data:"{'Partno':'"+part+"','Opertaion':'"+opr+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
                                    type:"POST",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function(msg)
                                    {
                                        if(msg.d=="S")
                                        {
                                        }
                                        else
                                        {
                                        }   
                                    },
                                    error:function()
                                    {}
                              });
                    
                    },
                    error:function()
                    {}
              });
   
           
     
    });
 });
 
 $(function()
{
    $('#spn_closehpop').click(function()
    {
         loadevent();
         var modal = document.getElementById('myModal');
         modal.style.display = "none";
         
    });
});  


// getmasteradmindesc

function getdescription(partno)
{

$.ajax({
        url:"../Master/Default.aspx/getadmindesc",
        data:"{'Partno':'"+partno+"'}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            if(msg.d!="F")
            {
               
                $('#spn_desc').text(msg.d);
                $('#spn_desc1').text(msg.d);
            }
        },
        error:function()
        {}
      });
}

 
 //design partof qualitysheet
function get_designvalue(partno,operation,unit,cell)
{
var newWidth = 0;
var dynwidth=0;
var max='';
var min='';
var mean='';
var ymax='';
var ymin='';
var others='';
   var tot=0;
        $.ajax({
                url:"../Master/Default.aspx/GetadminQualitydesign",
                data:"{'Partno':'"+partno+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(data) {
                totlen=data.d.length;
                    var tbl='<div><table width="100%"><tr>';
                    var ttbl='<div><table width="100%"><tr><td><table>';
                    ttbl+='<tr style="border: solid 1.4px #fff;"> <td class="style58" colspan="6" style="text-align:center; width:500px; background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;"><span>Frequency</span> </td></tr>';
                    ttbl+='<tr style="border: solid 1.4px #fff;"> <td class="style58" colspan="6" style="text-align:center; width:500px; background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;"><span>Dimensions</span> </td></tr>';
                    ttbl+='<tr style="border: solid 1.4px #fff;"> <td class="style58" colspan="6" style="text-align:center; width:500px; background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;"><span>Upper Specification</span> </td></tr>';
                    ttbl+='<tr style="border: solid 1.4px #fff;"> <td class="style58" colspan="6" style="text-align:center; width:500px; background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;"><span>Mean</span> </td></tr>';
                    ttbl+='<tr style="border: solid 1.4px #fff;"> <td class="style58" colspan="6" style="text-align:center; width:500px; background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;"><span>Lower Specification</span> </td></tr>';
                    ttbl+='</table></td>';
                    ttbl+='<td><table><tr>';
                    for (var i = 0; i < data.d.length; i++) {
                    if(data.d[i].Cellvalue!="" && data.d[i].Cellvalue!="0" && data.d[i].Cellvalue!=null)
                    {
                        max+=","+data.d[i].UpperSpecification;
                        min+=","+data.d[i].LowerSpecification;
                        mean+=","+data.d[i].Mean;
                        
                    }
                    if(data.d[i].Cellvalue=="" ||data.d[i].Cellvalue =="0" || data.d[i].Cellvalue == null)
                    {
                       others+=","+data.d[i].UpperSpecification;
                    }
                       tbl+='<td style="border:none;"><div id=div_'+i+'  style="float: left;" ><table id="Maintable" style=" border-collapse: collapse;"><tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:198.5px;height:14.5pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Frequency + '</span> </td></tr><tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:198.5px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Dimensions + '</span> </td></tr><tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:198.5px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].UpperSpecification + '</span> </td></tr><tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td style="text-align:center;width:198.5px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].Mean + '</span></td></tr><tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td style="text-align:center;width:198.5px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].LowerSpecification + '</span> </td></tr></table></div></td>';
                       ttbl+='<td style="border:none;"><div id=div_'+i+'  style="float: left;" ><table id="Maintable" style=" border-collapse: collapse;"><tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:198.5px;height:14.5pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Frequency + '</span> </td></tr><tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:198.5px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Dimensions + '</span> </td></tr><tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:198.5px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].UpperSpecification + '</span> </td></tr><tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td style="text-align:center;width:198.5px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].Mean + '</span></td></tr><tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td style="text-align:center;width:198.5px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].LowerSpecification + '</span> </td></tr></table></div></td>';
                    }
                     tbl+='</tr></table></div>';
                     $('#div_dyn').html(tbl);
                     
                     ttbl+='</tr></table></td>';
                     ttbl+='</tr></table></div>';
                     $('#div_qualitysheet').html(ttbl);
                     
                     $('#hdn_max').val(max);
                     $('#hdn_min').val(min);
                     rmax=max.split(",");
                     rmin=min.split(",");
                     ymean=mean.split(",");
                     other=others.split(",");
                     for(var count=0;count<rmax.length;count++)
                     {
                        if(rmax[count]=="" || rmax[count]==",")
                        {
                        }
                        else
                        {
                            var ay='';
                            var by='';
                            var mmax=rmax[count];
                            var mmin=rmin[count];
                            var yymean=ymean[count];
                            var maxmin=parseFloat(mmax)-parseFloat(mmin);
                            var maxminper=maxmin*0.6;
                            var div=parseFloat(maxminper/2);
                            var maxy=parseFloat(yymean)+parseFloat(div);
                            var miny=parseFloat(yymean)-parseFloat(div);
                            ymax+=","+maxy;
                            ymin+=","+miny;
                        }
                     }
                      $('#hdn_ymax').val(ymax);
                      $('#hdn_ymin').val(ymin);
                      showheadervalues(); 
                      getmaxmin();
                      tot=data.d.length;
                      newWidth=parseInt(tot)*(200);
                      dynwidth=newWidth+parseInt(265)+parseInt(105);
                      $("#div_width_dyn").width(dynwidth)
                      $("#div_headerlabel").width(dynwidth);
                      $("#div_lbl").width(dynwidth);
                      $("#div_tab").width(dynwidth); 
                      $("#wrap").width(dynwidth+613);                      
//                      var totalwidth=(dynwidth+613)/7;
                      var totalwidth=(dynwidth+613)/1.2;
                      //totalwidth=totalwidth-0.5;
                      totalwidth=totalwidth-0.5;
//                      totalwidth=totalwidth-1800;
//                      $('#hdn_liwidth').val(totalwidth);
//                      $("#link_master").width(totalwidth);       
                      $("#link_production1").width(300);
                      $("#link_planteff").width(300);
                      $("#link_dynQScreation").width(300);
                      $("#link_fixture").width(300);       
                      $("#link_prdata").width(300);       
                      $("#link_reports").width(300);       
                      $("#link_log").width(300);  
                      $("#linke_upload").width(300);  
                      $("#linke_stopentry").width(300);  
                      $("#linke_template").width(300);  
                      $("#linke_downtimetemp").width(300);  
                      $("#linke_timetry").width(300);  
                      $("#link_effen").width(300);  
                      $("#link_fixed").width(300);  
                      $("#link_dymaster").width(300);  
                      $("#link_dynvalues").width(300);  
                      
                      $("#link_fileupload").width(300);
                      $("#link_pdupload").width(300);
                      $("#link_view").width(300);  
                      $("#link_form").width(300);  
                      $("#link_dmt").width(300);
                      $("#link_plannedstop").width(300);
                      $("#link_barcodetemplate").width(300);
                      $("#link_downtimeloss").width(300);
                      $("#link_cycletime").width(300);
                      $("#link_laboreff").width(300);
                      $("#link_fixedtime").width(300);
                      $("#link_dynmaster").width(300);
                      $("#link_dynvalues").width(300);
                      $("#link_unit").width(300);
                      $("#link_type").width(300);
                      $("#link_line").width(300);
                      $("#link_spare").width(300);
                      $("#link_model").width(300);
                      $("#link_fixcreation").width(300);
                      $("#link_fixvalues").width(300);
                      $("#link_chart").width(300);  
                      $("#link_qcrpt").width(300);  
                      $("#link_effrpt").width(300);  
                      $("#link_oeelet").width(300);  
                      $("#link_fixrpt").width(300);
                      $("#link_fixchange").width(300);
                      $("#link_fbrpt").width(300);
                      $("#link_feedback").width(300); 
                      $("#link_fixture").width(300);
                     // getmasterlinkpages();      
                },
                error:function()
                {}
              });
}
function getmaxmin()
{
        var part=$('#hdn_partno1').val();
        var operation=$('#hdn_operation').val();
        var unit=$('#hdn_unit').val();
        var cell=$('#hdn_cell').val();
        var max='';
        $.ajax({
                url:"../Master/Default.aspx/Get_adminmaxmin",
                data:"{'Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    for(var m=0;m<msg.d.length;m++)
                    {
                        max+=","+ msg.d[m].Max+","+msg.d[m].Min+","+msg.d[m].Cellvalue;
                    }
                     MaxMin=max.split(",");
                    showval_label(MaxMin);
                },
                error:function()
                {}
              });
            
}
function showval_label(MaxMin)
{
        var part=$('#hdn_partno1').val();
        var operation=$('#hdn_operation').val();
        var unit=$('#hdn_unit').val();
        var cell=$('#hdn_cell').val();
        var mach=$('#hdn_mach1').val();
        var operator=$('#hdn_operator').val();
        var minmax=[];
        minmax=MaxMin;
        var tot=$('#hdn_instcount').val();
        $.ajax({
                url:"../Master/Default.aspx/ReadadminExistinValues",
                data:"{'Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"','Shift':'"+$('#hdn_shift1').val()+"','Date':'"+$('#hdn_date1').val()+"','Machine':'"+$('#hdn_mach1').val()+"','Operator':'"+$('#hdn_operator').val()+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg!=null && msg!="")
                    {
                        var time=1;
                        var edit=1;
                        var cmt=1;
                        var marphs=$('#hdn_marph').val();
                        var marphs1=$('#hdn_marph').val();
                        
                        
                      if(marphs1=="")
                      {
                       marphs1="0";
                      }
                      if(marphs=="")
                      {marphs="0";
                      }
                      marphs=parseInt(5)+parseInt(marphs*2);
                        var total=parseInt(marphs)+parseInt(tot);
                        cmt=cmt+parseInt(total);
                        time=time+cmt;
                        edit=edit+time;
                        var rowid=1;
                        var tbl="<div style='margin-left:-487px;'><table id='tb_label'  style='border: 0px solid black;border-collapse: collapse;background-color:#eefaff;'>";
                        var _tbl="<div><table id='tb_label' width='' style='border: 0px solid black;border-collapse: collapse;margin-left: -551px;background-color:#eefaff;'>";
                        for(var i=0;i<msg.d.length;i++)
                        {
                                var _cellval=0;
                                var _cellval1=0;
                                 var _m=1;
                                 var _m1=1;
                                 var reject='';
//                                $('#hdn_arrylength').val(msg.d[i].arr_val.length);
                                $('#hdn_arrylength').val(msg.d.length);
                                tbl+="<tr style=''><td style='border:none;'><div style='border:none;margin-top:-2px;display:block;'id='div_edit_"+i+"'><table style='border:none;border-collapse: collapse;'><tr style='border:none;height:30px;'><td style='text-align:center;height:10pt;width:95px;' class='styleHDR'><span id='spn_date'>"+msg.d[i].arr_val[0]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:93px;' class='styleHDR'><span id='spn_pidno'>"+msg.d[i].arr_val[1]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:47px;' class='styleHDR'><span id='spn_Shift'>"+msg.d[i].arr_val[2]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:98px;' class='styleHDR'><span id='spn_opt'>"+msg.d[i].arr_val[3]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:50px;'  class='styleHDR'><span id='Textslno'>"+msg.d[i].arr_val[4]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:98px;'  class='styleHDR'><span id='Textheatcode'>"+msg.d[i].arr_val[5]+"</span></td>";
                                _tbl+="<tr><td style='border:none;'><div style='border:none;margin-top:-2px;display:block;'id='div_edit_"+i+"'><table style='border:none;border-collapse: collapse;'><tr style='border:none;'><td style='text-align:center;height:10pt;width:98px;' class='styleHDR'><span id='spn_date'>"+msg.d[i].arr_val[0]+"</span></td>";
                                _tbl+="<td style='text-align:center;height:10pt;width:93px;' class='styleHDR'><span id='spn_pidno'>"+msg.d[i].arr_val[1]+"</span></td>";
                                _tbl+="<td style='text-align:center;height:10pt;width:47px;' class='styleHDR'><span id='spn_Shift'>"+msg.d[i].arr_val[2]+"</span></td>";
                                _tbl+="<td style='text-align:center;height:10pt;width:98px;' class='styleHDR'><span id='spn_opt'>"+msg.d[i].arr_val[3]+"</span></td>";
                                _tbl+="<td style='text-align:center;height:10pt;width:50px;'  class='styleHDR'><span id='Textslno'>"+msg.d[i].arr_val[4]+"</span></td>";
                                _tbl+="<td style='text-align:center;height:10pt;width:98px;'  class='styleHDR'><span id='Textheatcode'>"+msg.d[i].arr_val[5]+"</span></td>";
                                 var d=1;
                                 
                                 for (var k=6;k<=total;k++)
                                {
                                    _cellval+=3;
                                    var _instcount=minmax[_cellval];
                                    if(_instcount!="" && _instcount!="0" && _instcount!=null)
                                    {
                                    
                                        var _max=minmax[_m];
                                        _m+=1;
                                        var _min=minmax[_m];
                                         _m+=2;
                                         d+=1;
                                         for(var m=0;m<_instcount;m++)
                                         {
                                            var val=k+m;
                                            var values=parseFloat(msg.d[i].arr_val[k+m]);
                                            var ymax='';
                                            var sty='';
                                            var ymin='';
//                                            if(k % 2 ==0)
//                                            {
//                                               
//                                                d+=1;
//                                            }
                                            var count=parseInt(d)-parseInt(1);
                                            var mmax=rmax[count];
                                            var mmin=rmin[count];
                                            var yymean=ymean[count];
                                            var maxmin=parseFloat(mmax)-parseFloat(mmin);
                                            var maxminper=maxmin*0.6;
                                            var div=parseFloat(maxminper)/parseFloat(2);
                                            var maxy=parseFloat(yymean)+parseFloat(div);
                                            var miny=parseFloat(yymean)-parseFloat(div);
                                            var n = maxy.toString(); 
                                            var n1 = miny.toString(); 
                                            n=n.substring(0,6);
                                            n1=n1.substring(0,6);
                                            if(values > parseFloat(mmax) || values < parseFloat(mmin))
                                            {
                                                sty="background-color:red";
                                            }
                                            else if(values >= parseFloat(n1) && values <= parseFloat(n))
                                            {
                                                
                                                 sty="background-color:yellow";
                                            }
                                            else
                                            {
                                                sty="background-color:green";
                                            }
                                             tbl+='<td style="text-align:center;width:100px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k+m]+ '</td>';
                                             _tbl+='<td style="text-align:center;width:101.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k+m]+ '</td>';
                                         }
                                         
                                         k+=1;
                                    }
                                    else
                                    {
                                        var _max=minmax[_m];
                                        var _min=minmax[_m + 1];
                                        var values1=parseFloat(msg.d[i].arr_val[k]);
                                        var vis_val=msg.d[i].arr_val[k];
                                        if(values1 > parseFloat(_max) || values1 < parseFloat(_min)|| vis_val == "not ok"|| vis_val =="notok" || vis_val =="NOT OK" || vis_val =="NOTOK")
                                        {
                                            var sty='background-color:red;'
                                        }
                                        else if(vis_val =="-")
                                        {
                                            var sty='background-color:orange;'
                                        }
                                        else
                                        {
                                            var sty='background-color:none;'
                                        }
                                        if(msg.d[i].arr_val[k]=="None")
                                        {
                                            tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR"></td>';
                                            _tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k]+ '</td>';
                                        }
                                        else
                                        {
                                            tbl+='<td style="text-align:center;width:203px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k]+ '</td>';
                                            _tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k]+ '</td>';
                                        }
                                        _m+=3;
                                    }
                                    
                                        
                                }
                                
//                                for (var k=6;k<=marphs;k++)
//                                {
//                                            var _max=minmax[_m];
//                                            _m+=1;
//                                            var _min=minmax[_m];
//                                             
//                                            var values=parseFloat(msg.d[i].arr_val[k]);
//                                            var ymax='';
//                                            var sty='';
//                                            var ymin='';
//                                            if(k % 2 ==0)
//                                            {
//                                               
//                                                d+=1;
//                                            }
//                                            var count=parseInt(d)-parseInt(1);
//                                            var mmax=rmax[count];
//                                            var mmin=rmin[count];
//                                            var yymean=ymean[count];
//                                            var maxmin=parseFloat(mmax)-parseFloat(mmin);
//                                            var maxminper=maxmin*0.6;
//                                            var div=parseFloat(maxminper)/parseFloat(2);
//                                            var maxy=parseFloat(yymean)+parseFloat(div);
//                                            var miny=parseFloat(yymean)-parseFloat(div);
//                                            var n = maxy.toString(); 
//                                            var n1 = miny.toString(); 
//                                            n=n.substring(0,6);
//                                            n1=n1.substring(0,6);
//                                            if(values > parseFloat(mmax) || values < parseFloat(mmin))
//                                            {
//                                                sty="background-color:red";
//                                            }
//                                            else if(values >= parseFloat(n1) && values <= parseFloat(n))
//                                            {
//                                                
//                                                 sty="background-color:yellow";
//                                            }
//                                            else
//                                            {
//                                                sty="background-color:green";
//                                            }
//                                         
//                                             tbl+='<td style="text-align:center;width:101.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k]+ '</td>';
//                                             _tbl+='<td style="text-align:center;width:101.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k]+ '</td>';
//                                             if(k%2==1)
//                                             {
//                                                 _m+=1;
//                                             }
//                                             else
//                                             {
//                                                 _m+=-1;
//                                             }
//                                        
//                                }
//                                for (var l=k;l<=total;l++)
//                                {
//                                     var _max=minmax[_m];
//                                     var values1=parseFloat(msg.d[i].arr_val[l]);
//                                     if(values1 > parseFloat(_max))
//                                     {
//                                        var sty='background-color:red;'
//                                     }
//                                     else
//                                     {
//                                         var sty='background-color:none;'
//                                     }
//                                     if( msg.d[i].arr_val[l]=="None")
//                                     {
//                                        tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR"></td>';
//                                        _tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR"></td>';
//                                     }
//                                     else
//                                     {
//                                        tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[l]+ '</td>';
//                                        _tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[l]+ '</td>';
//                                     }
//                                    
//                                    
//                                   _m+=2;
//                                }
                                for (var a=k;a<=cmt;a++)
                                {
                                  tbl+='<td style="text-align:center;width:100px;" class="styleHDR">' + msg.d[i].arr_val[a]+ '</td>';
                                  _tbl+='<td style="text-align:center;width:100px;" class="styleHDR">' + msg.d[i].arr_val[a]+ '</td>';
                                }
                                for (var n=a;n<=time;n++)
                                {
                                  tbl+='<td style="text-align:center;width:100px;" class="styleHDR">' + msg.d[i].arr_val[n]+ '</td>';
                                  _tbl+='<td style="text-align:center;width:100px;" class="styleHDR">' + msg.d[i].arr_val[n]+ '</td>';
                                }
                                for (var x=n;x<=edit;x++)
                                {
                                  tbl+='<td style="border: 1px solid black;width:97px;"><input type="image" src="../images/Editnew.jpg"  id="divedit_'+i+'" alt="Edit"   style="width:25px;margin-left:35px;" onclick="javascript:show1('+i+');"/></td>';
                                }
                                tbl+="</tr></table></div>";
                                _tbl+="</tr></table></div>";
                                tbl+="<div style='border:none;margin-top:-2px;display:none;'id='div_update_"+i+"'><table style='border:none;border-collapse: collapse;background-color:#fff;'><tr style='border:none;height:30px;'><td style='text-align:center;height:10pt;width:95px;' class='styleHDR'><span id='spn_date'>"+msg.d[i].arr_val[0]+"</span></td>";
                                //tbl+="<td style='text-align:center;height:10pt;width:93px;' class='styleHDR'><span id='spn_pidno'>"+msg.d[i].arr_val[1]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:93px;' class='styleHDR'><input type='text' id='spn_pidno"+i+"' style='height:20pt;width:93px;border:none;text-align:center;' class='RghTxtBox_dyn' value=" +msg.d[i].arr_val[1]+ "></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:47px;' class='styleHDR'><span id='spn_Shift'>"+msg.d[i].arr_val[2]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:98px;' class='styleHDR'><span id='spn_opt'>"+msg.d[i].arr_val[3]+"</span></td>";
//                                tbl+="<td style='text-align:center;height:10pt;width:50px;'  class='styleHDR'><span id='Textslno'>"+msg.d[i].arr_val[4]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:50px;' class='styleHDR'><input type='text' id='Textslno"+i+"' style='height:20pt;width:50px;border:none;text-align:center;' class='RghTxtBox_dyn' value=" +msg.d[i].arr_val[4]+ "></td>";
                                //tbl+="<td style='text-align:center;height:10pt;width:98px;' class='styleHDR'><span id='Textheatcode'>"+msg.d[i].arr_val[5]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:104.5px;' class='styleHDR'><input type='text' id='Textheatcode"+i+"' style='height:20pt;width:98px;border:none;text-align:center;' class='RghTxtBox_dyn' value=" +msg.d[i].arr_val[5]+ "></td>";
                                var d1=1;
                                
                                for (var k=6;k<=total;k++)
                                {
                                    _cellval1+=3;
                                    var _instcount1=minmax[_cellval1];
                                    if(_instcount1!="" && _instcount1!="0" && _instcount1!=null)
                                    {
                                    
                                         var _max=minmax[_m1];
                                         _m1+=1;
                                         var _min=minmax[_m1];
                                         _m1+=2;
                                         d1+=1;
                                          for(var m=0;m<_instcount;m++)
                                         {
                                         
                                            var val=k+m
                                             var values=parseFloat(msg.d[i].arr_val[val]);
                                             var ymax='';
                                               var sty='';
                                                var ymin='';
//                                                if(k % 2 ==0)
//                                                {
//                                                   
//                                                    d1+=1;
//                                                }
                                                var count=parseInt(d1)-parseInt(1);
                                                var mmax=rmax[count];
                                                var mmin=rmin[count];
                                                var yymean=ymean[count];
                                                var maxmin=parseFloat(mmax)-parseFloat(mmin);
                                                var maxminper=maxmin*0.6;
                                                var div=parseFloat(maxminper)/parseFloat(2);
                                                var maxy=parseFloat(yymean)+parseFloat(div);
                                                var miny=parseFloat(yymean)-parseFloat(div);
                                                var n = maxy.toString(); 
                                                var n1 = miny.toString(); 
                                                n=n.substring(0,6);
                                                n1=n1.substring(0,6);
                                                if(values > parseFloat(mmax) || values < parseFloat(mmin))
                                                {
                                                    sty="background-color:red";
                                                    reject='1';
                                                }
                                                else if(values >= parseFloat(n1) && values <= parseFloat(n))
                                                {
                                                    
                                                     sty="background-color:yellow";
                                                }
                                                else
                                                {
                                                    sty="background-color:green";
                                                }
                                                  tbl+='<td style="text-align:center;width:101.5px;'+sty+'" class="styleHDR"><input type="text" id="txt_value_'+val+''+i+'"  style="width:95px;height: 15pt;border:none;text-align:center;'+sty+'" class="MrpTxtBox_dyn" value=' + msg.d[i].arr_val[val]+ ' onblur="javascript:checkuprange('+val+','+i+','+count+');"></td>';
                                           }
                                           k+=1;
//                                              if(k%2==1)
//                                             {
//                                                 _m1+=1;
//                                             }
//                                             else
//                                             {
//                                                 _m1+=-1;
//                                             }
                                        }
                                        else
                                        {
                                        var count1=0;
                                            if(msg.d[i].arr_val[k]!=null && msg.d[i].arr_val[k]!="")
                                            {
                                                count1+=1;
                                                 var _max=minmax[_m1];
                                                  var _min=minmax[_m1 + 1];
                                                 var values1=parseFloat(msg.d[i].arr_val[k]);
                                                 var vis_val=msg.d[i].arr_val[k];
                                                 if(values1 > parseFloat(_max) || values1 < parseFloat(_min) || vis_val == "not ok"|| vis_val =="notok" || vis_val =="NOT OK" || vis_val =="NOTOK")
                                                 {
                                                    var sty='background-color:red;'
                                                    reject='1';
                                                 }
                                                 else if(vis_val =="-")
                                                 {
                                                   var sty='background-color:orange;'
                                                 }
                                                 else
                                                 {
                                                     var sty='background-color:none;'
                                                 }
                                                 if(msg.d[i].arr_val[k]=="None")
                                                 {
                                                   tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR"><input type="text"  id="txt_value_'+k+''+i+'" style="width:195px;height: 20pt;border:none;text-align:center;'+sty+'" class="RghTxtBox_dyn" value="" disabled="disabled"></td>';
                                                 }
                                                 else{
                                                   tbl+='<td style="text-align:center;width:205px;'+sty+'" class="styleHDR"><input type="text"  id="txt_value_'+k+''+i+'" style="width:155px;height: 20pt;border:none;text-align:center;'+sty+'" class="RghTxtBox_dyn" value=' + msg.d[i].arr_val[k]+ '></td>';
                                                   }
                                                   _m1+=3;
                                            }
                                            else
                                            {
                                                tbl+='<td style="text-align:center;width:205px" class="styleHDR"><input type="text"  id="txt_value_'+k+''+i+'" style="width:155px;height: 15pt;border:none;text-align:center;" class="RghTxtBox_dyn" value="" disabled="disabled"></td>';
                                            }
                                        }
                                              
                                }
                                
//                                for (var k=6;k<=marphs;k++)
//                                {
//                                         var _max=minmax[_m1];
//                                         _m1+=1;
//                                           var _min=minmax[_m1];
//                                           var values=parseFloat(msg.d[i].arr_val[k]);
//                                           var ymax='';
//                                           var sty='';
//                                            var ymin='';
//                                            if(k % 2 ==0)
//                                            {
//                                               
//                                                d1+=1;
//                                            }
//                                            var count=parseInt(d1)-parseInt(1);
//                                            var mmax=rmax[count];
//                                            var mmin=rmin[count];
//                                            var yymean=ymean[count];
//                                            var maxmin=parseFloat(mmax)-parseFloat(mmin);
//                                            var maxminper=maxmin*0.6;
//                                            var div=parseFloat(maxminper)/parseFloat(2);
//                                            var maxy=parseFloat(yymean)+parseFloat(div);
//                                            var miny=parseFloat(yymean)-parseFloat(div);
//                                            var n = maxy.toString(); 
//                                            var n1 = miny.toString(); 
//                                            n=n.substring(0,6);
//                                            n1=n1.substring(0,6);
//                                            if(values > parseFloat(mmax) || values < parseFloat(mmin))
//                                            {
//                                                sty="background-color:red";
//                                                reject='1';
//                                            }
//                                            else if(values >= parseFloat(n1) && values <= parseFloat(n))
//                                            {
//                                                
//                                                 sty="background-color:yellow";
//                                            }
//                                            else
//                                            {
//                                                sty="background-color:green";
//                                            }
//                                              tbl+='<td style="text-align:center;width:101.5px;'+sty+'" class="styleHDR"><input type="text" id="txt_value_'+k+''+i+'"  style="width:95px;height: 15pt;border:none;text-align:center;'+sty+'" class="MrpTxtBox_dyn" value=' + msg.d[i].arr_val[k]+ ' onblur="javascript:checkuprange('+k+','+i+','+count+');"></td>';
//                                              if(k%2==1)
//                                             {
//                                                 _m1+=1;
//                                             }
//                                             else
//                                             {
//                                                 _m1+=-1;
//                                             }
//                                              
//                                }
//                                for (var l=k;l<=total;l++)
//                                {
//                                    if(msg.d[i].arr_val[l]!=null && msg.d[i].arr_val[l]!="")
//                                    {
//                                         var _max=minmax[_m1];
//                                         var values1=parseFloat(msg.d[i].arr_val[l]);
//                                         if(values1 > parseFloat(_max))
//                                         {
//                                            var sty='background-color:red;'
//                                            reject='1';
//                                         }
//                                         else
//                                         {
//                                             var sty='background-color:none;'
//                                         }
//                                         if(msg.d[i].arr_val[l]=="None")
//                                         {
//                                            tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR"><input type="text"  id="txt_value_'+l+''+i+'" style="width:195px;height: 20pt;border:none;text-align:center;'+sty+'" class="RghTxtBox_dyn" value="" disabled="disabled"></td>';
//                                         }
//                                         else
//                                         {
//                                            tbl+='<td style="text-align:center;width:205px;'+sty+'" class="styleHDR"><input type="text"  id="txt_value_'+l+''+i+'" style="width:155px;height: 20pt;border:none;text-align:center;'+sty+'" class="RghTxtBox_dyn" value=' + msg.d[i].arr_val[l]+ '></td>';
//                                         }
//                                           
//                                           _m1+=2;
//                                    }
//                                    else
//                                    {
//                                       tbl+='<td style="text-align:center;width:205px" class="styleHDR"><input type="text"  id="txt_value_'+l+''+i+'" style="width:155px;height: 15pt;border:none;text-align:center;" class="RghTxtBox_dyn" value="" disabled="disabled"></td>';
//                                    }
//                                     
//                                }
                                for (var a=k;a<=cmt;a++)
                                {
                                  tbl+='<td style="text-align:center;width:100px;" class="styleHDR"><input type="text" id="txt_value_'+a+''+i+'" style="width:100px;height: 15pt;border:none;text-align:center;" class="TxtBox_dyn9" value=' + msg.d[i].arr_val[a]+ '></td>';
                                }
                                for (var n=a;n<=time;n++)
                                {
                                  tbl+='<td style="text-align:center;width:100px;" class="styleHDR"><span id="span_value_'+a+''+i+'" style="width:100px;height: 15pt;border:none;text-align:center;" class="TxtBox_dyn9" >' + msg.d[i].arr_val[n]+ '</span></td>';
                                }
                                for (var x=n;x<=edit;x++)
                                {
                                    var id=msg.d[i].arr_val[x];
                                    //tbl+='<td style="border: 1px solid black;width:99px;"><div align="center" style="margin-left:20px;" id="update_'+i+'"><table><tr><td style="width:50px;"><input type="image" src="../images/update.jpg"   alt="Edit" class="inputClass"  style="width:25px;" onclick="javascript:update('+msg.d[i].arr_val[x]+','+i+','+marphs1+','+tot+','+msg.d[i].arr_val[1]+');"/></td><td style="width:50px;"><input type="image" src="../images/Delete.png"   alt="Edit" class="inputClass"  style="width:25px;" onclick="javascript:Cancel('+i+');"/></td></tr></table></div></td>';
                                    tbl+='<td style="border: 1px solid black;width:95px;"><div align="center" style="margin-left:20px;" id="update_'+i+'"><table><tr><td style="width:50px;"><input type="image" src="../images/update.jpg"   alt="Edit" class="inputClass"  style="width:25px;" onclick="javascript:update('+msg.d[i].arr_val[x]+','+i+','+marphs1+','+tot+');"/></td><td style="width:50px;"><input type="image" src="../images/Delete.png"   alt="Edit" class="inputClass"  style="width:25px;" onclick="javascript:Cancel('+i+');"/></td></tr></table></div></td>';
                                    
                                     $.ajax({
                                            url:"../Master/Default.aspx/UpdateadminRejectValues",
                                            data:"{'ID':'"+id+"','Reject':'"+reject+"','Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"'}", 
                                            type:"POST",
                                            contentType: "application/json; charset=utf-8",
                                            dataType: "json",
                                            success: function(msg)
                                            {
                                                if(msg.d=="S")
                                                {
                                                   
                                                }
                                            },
                                            error:function()
                                            {}
                                          });
                                }
                                tbl+="</tr></table></div>";
                                tbl+="</td></tr>";
                                rowid+=1;
                      }
                        tbl+="</table></div>";
                        _tbl+="</table></div>";
                        $("#div_lbl").html(tbl);
                        
                        $("#div_lbl1").html(_tbl);
                        var table=document.getElementById("tb_label");
                        tid=table.rows.length;
                        $('#hdnrowid').val(tid);
                        //showtxbx();  
                        getotqty(); 
                        if(excel== 1)
                        {
                            exportoexcel(); 
                        }
                    }
                    else
                    {
                   
                         //showtxbx();
                    }
                },
                error:function()
                {}
              });
}
function getinstcount()
{
    var part=$('#hdn_partno1').val();
    var operation=$('#hdn_operation').val();
    var unit=$('#hdn_unit').val();
    var cell=$('#hdn_cell').val();
    $.ajax({
        url:"../Master/Default.aspx/getadmincount",
        data:"{'Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(data)
        {
            
            tot=parseInt(data.d);
            $('#hdn_instcount').val(tot);
            
         },
             error:function()
        {}
      });
     
}
function getotqty()
{
        var part=$('#hdn_partno1').val();
        var operation=$('#hdn_operation').val();
        var unit=$('#hdn_unit').val();
        var cell=$('#hdn_cell').val();
    $.ajax({
       url:"../Master/Default.aspx/getadminrowcount",
        data:"{'Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"','Shift':'"+$('#hdn_shift1').val()+"','Date':'"+$('#hdn_date1').val()+"','Machine':'"+$('#hdn_mach1').val()+"','Operator':'"+$('#hdn_operator').val()+"'}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(data)
        {
            if(data!=null && data!="")
            {
                for(var i=0;i<data.d.length;i++)
                {
                    if(data.d[i].Accept=="F")
                    {
                        var url="../Home.aspx";
                        window.top.location.href=url;
                    }
                    else
                    {
                         $('#spn_tot_qty').text(data.d[i].Accept);
                         $('#spn_rej_qty').text(data.d[i].Reject);
                         $('#spn_acc_qty').text(data.d[i]._Accept);
                    }
                }
            }
         },
             error:function()
        {}
      });
}
function Cancel(id)
{
     $('#div_update_'+id+'').hide();
     $('#div_edit_'+id+'').show();
}
function show1(id)
{
    var arry= $('#hdn_arrylength').val();
    for(var i=0;i<arry;i++)
    {
        if(i==id)
        {
            $('#div_edit_'+id+'').hide();
            $('#div_update_'+id+'').show();
        }
        else
        {
            $('#div_update_'+i+'').hide();
            $('#div_edit_'+i+'').show();
        }
    }
}

function update(id,r,marphs,tott)
{
var part=$('#hdn_partno1').val();
var operation=$('#hdn_operation').val();
var unit=$('#hdn_unit').val();
var cell=$('#hdn_cell').val();
           
var max='';
$.ajax({
        url:"../Master/Default.aspx/Get_adminmaxmin",
        data:"{'Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            for(var m=0;m<msg.d.length;m++)
            {
                max+=","+ msg.d[m].Max+","+msg.d[m].Min+","+msg.d[m].Cellvalue;
            }
             MaxMin=max.split(",");
             
            var minmax=[];
            minmax=MaxMin;
            
            var dt= $('#hdn_date').val();
            var user=$('#spn_opt').text();
            var shift=$('#spn_Shift').text();

        var operator=$('#hdn_operator').val();
            $('#hdn_shift1').val(shift);
        //    var sno=$('#Textslno').val();
        //    var code=$('#Textheatcode').val();
            var sno=$('#Textslno'+r+'').val();
            if(sno == "")
            {
                $('#Textslno'+r+'').css( "background-color","pink" );
                alert('ENTER VALUE');
                $('#Textslno'+r+'').focus();
                return;
            }
            var pidno=$('#spn_pidno'+r+'').val();
            var code=$('#Textheatcode'+r+'').val();
            var textvalues='';//dt+","+shift+","+user;
            var row= $('#hdn_arrylength').val();
            var marph=parseInt(5)+parseInt(marphs*2);
            var total=marph+parseInt(tott);
            var avg="";
            var tot=0;
            var d=1;
            var _cellval=0;
            var _m=1;
            for (var k=6;k<=total+1;k++)
            {
                _cellval+=3;
                var _instcount=minmax[_cellval];
                if(_instcount!="" && _instcount!="0" && _instcount!=null)
                {
                    var _max=minmax[_m];
                    _m+=1;
                    var _min=minmax[_m];
                     _m+=2;
                     d+=1;
                     for(var m=0;m<_instcount;m++)
                     {
                        var val=k+m;
                        if($('#txt_value_'+val+''+r+'').is(':disabled'))
                        {   
                            textvalues+=",None";
                        }
                        else
                        {
                            var txt=$('#txt_value_'+val+''+r+'').val();
                            if(txt=="")
                            {
                                $('#txt_value_'+val+''+r+'').css( "background-color","pink" );
                                alert('ENTER VALUE');
                                $('#txt_value_'+val+''+r+'').focus();
                                return;
                            }
                            
                            
                            else
                            {
                                $('#txt_value_'+val+''+r+'').css( "background-color","#fff" );
                                textvalues+=","+txt;
                                tot=tot+parseFloat(txt);
                            }
                        }
                     }
                    var tot1=tot/2;
                    tot=0;
                    avg+=","+tot1;
                    k+=1;
                   
                }
                else
                {
                    if($('#txt_value_'+k+''+r+'').is(':disabled'))
                    {   
                        textvalues+=",None";
                    }
                    else
                    {
                        var txt=$('#txt_value_'+k+''+r+'').val();
                        if(txt=="")
                        {
                            $('#txt_value_'+k+''+r+'').css( "background-color","pink" );
                            alert('ENTER VALUE');
                            $('#txt_value_'+k+''+r+'').focus();
                            return;
                        }
                        else
                        {
                            $('#txt_value_'+k+''+r+'').css( "background-color","#fff" );
                            textvalues+=","+txt;
                        }
                    }
                    _m+=3;
                }
            }
            
//            for(var j=6;j<=marph;j++)
//            {
//                if($('#txt_value_'+j+''+r+'').is(':disabled'))
//                {   
//                    textvalues+=",None";
//                }
//                else
//                {
//                    var txt=$('#txt_value_'+j+''+r+'').val();
//                    if(txt=="")
//                    {
//                        $('#txt_value_'+j+''+r+'').css( "background-color","pink" );
//                        alert('ENTER VALUE');
//                        $('#txt_value_'+j+''+r+'').focus();
//                        return;
//                    }
//                    else
//                    {
//                        $('#txt_value_'+j+''+r+'').css( "background-color","#fff" );
//                        textvalues+=","+txt;
//                        tot=parseFloat(tot)+parseFloat(txt);
//                    }
//                    if((j%2)==1)
//                    {
//                        var tot1=parseFloat(tot)/parseFloat(2);
//                        tot=0;
//                        avg+=","+tot1;
//                    }
//                }
//                
//            }
//            for(var z=j;z<=total+1;z++)
//            {
//                if($('#txt_value_'+z+''+r+'').is(':disabled'))
//                {   
//                    textvalues+=",None";
//                }
//                else
//                {
//                    var txt=$('#txt_value_'+z+''+r+'').val();
//                    if(txt=="")
//                    {
//                        $('#txt_value_'+z+''+r+'').css( "background-color","pink" );
//                        alert('ENTER VALUE');
//                        $('#txt_value_'+z+''+r+'').focus();
//                        return;
//                    }
//                    else
//                    {
//                        $('#txt_value_'+z+''+r+'').css( "background-color","#fff" );
//                        textvalues+=","+txt;
//                    }
//                }
//            }

           $.ajax({
                    url:"../Master/Default.aspx/TxtbxadminUpdatevalues",
                    data:"{'Pidno':'"+pidno+"','Sno':'"+sno+"','Code':'"+code+"','Texboxvalues':'"+textvalues+"','Average1':'"+avg+"','ID':'"+id+"','Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
                    type:"POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg)
                    {
                           if(msg.d=="S")
                           {
                           excel=1;
                             getotqty();
                             getmaxmin();
                            // showtxbx(); 
        //                    exportoexcel();
                           }
                    },
                    error:function()
                    {}
                    });
        },
        error:function()
        {}
      });
              
    
                        
                            
                       
    
}
function showheadervalues()
{
 var part=$('#hdn_partno1').val();
        var operation=$('#hdn_operation').val();
        var unit=$('#hdn_unit').val();
        var cell=$('#hdn_cell').val();
   
//             $.ajax({
//                url:"../Master/Default.aspx/getinstruments",
//                data:"{'Partno':'A17724Q','Opertaion':'1','Unit':'MBU','Cell':'Valve'}",
//                type:"POST",
//                contentType: "application/json; charset=utf-8",
//                dataType: "json",
//                success: function(msg)
//                {
//                    part=msg.d;
//                    comma=part.split(",");
                    var tbl1="<div style='float: left;'><table id='tbleheader' style='border: 0px solid black;border-collapse:collapse;background-color:#eefaff;' width='100%'><tr style='height:30px;background-color:#4C6C9F;'>";
                    var tbl_1="<div style='float: left;'><table id='tbleheader'  style='border: 0px solid black;border-collapse:collapse;margin-left:-551px;background-color:#eefaff;'><tr style='height:30px;background-color:#4C6C9F;'><td style='text-align:center;height:10pt;width:145px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>DATE</span></td><td style='text-align:center;height:10pt;width:88px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span style>PID</span></td><td style='text-align:center;height:10pt;width:75px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>SHIFT</span></td><td style='text-align:center;height:10pt;width:78px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>OPERATOR</span></td><td style='text-align:center;height:10pt;width:76px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Sl.No</span></td><td style='text-align:center;height:10pt;width:84px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>HEAT CODE</span></td>";
//                    for(var count=0;count<comma.length;count++)
//                    {
//                        if(comma[count]=="")
//                        {
//                        }
//                        else
//                        {
//                        alert(comma[count]);
                            $.ajax({
                                    url:"../Master/Default.aspx/GetadminheaderQsTxtbx_header1",
                                    data:"{'Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
                                    type:"POST",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function(msg) {
                                    var cellvalcount=0;
                                     for(var k=0;k<msg.d.length;k++)
                                     {
                                              Mrpval=(msg.d[k].Instrcount);
                                              if(msg.d[k].Cells !=null && msg.d[k].Cells !="0" && msg.d[k].Cells !="")
                                              {
//                                                $('#hdn_marph').val(Mrpval);
                                                 cellvalcount = parseInt(cellvalcount)+parseInt(Mrpval);
                                                 $('#hdn_marph').val(cellvalcount);
                                                 for (var p=1;p<=Mrpval;p++)
                                                  {
                                                   tbl1+='<td style="text-align:center;height:10pt;width:102px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>POS1</span></td><td style="text-align:center;height:10pt;width:99px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>POS2</span></td>';
                                                   tbl_1+='<td style="text-align:center;height:10pt;width:147.5px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>POS1</span></td><td style="text-align:center;height:10pt;width:128.5px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>POS2</span></td>';
                                                  }
                                                  
                                              }
                                              else
                                              {
                                             
                                                 for(var q=1;q<=Mrpval;q++)
                                                  {
                                                 
                                                     tbl1+='<td style="text-align:center;height:10pt;width:201.5px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>'+msg.d[k].ShortName+' '+q+'</span></td>';
                                                    tbl_1+='<td style="text-align:center;height:10pt;width:218px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>'+msg.d[k].ShortName+' '+q+'</span></td>';
                                                  }
                                              }
                                                
                                               
                                     }
                                      tbl1+="<td style='text-align:center;height:10pt;width:98px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Comments</span></td><td style='text-align:center;height:10pt;width:100px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Time</span></td><td style='text-align:center;height:10pt;width:98px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Action</span></td></tr></table></div>";
                                     tbl_1+="<td style='text-align:center;height:10pt;width:30px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Comments</span></td><td style='text-align:center;height:10pt;width:98px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Time</span></td></tr></table></div>";
                                     $("#div_headerlabel").html(tbl1);    
                                    $("#div_headerlabel1").html(tbl_1);    
                                         
                                          
                                    },
                                    error:function()
                                    {}
                                  });
                                   
                                   
//                        }
//                        
//                    }
//                                         tbl1+="<td style='text-align:center;height:10pt;width:146px;' class='styleHDR'><span>Comments</span></td><td style='text-align:center;height:10pt;width:100px;' class='styleHDR'><span>Action</span></td></tr></table></div>";
//                                         $("#div_headerlabel").html(tbl1);    
//                
//                },
//                error:function()
//                {}
//              });
}

function showtxbx()
{
var mrgvalue=0;
var rghvalue=0;
var Visualvalue=0;
var Mahrvalue=0;
var Plugvalue=0;
var CMMvalue=0;
var Pinvalue=0;
var Profilevalue=0;
var Borevalue=0;
var QDate="12/22/2015";
var QPidno="A17724Q";
var QShift="A";
var QOPERATOR="User";
 var currentdate = new Date(); 
                   var datetime =(currentdate.getMonth()+1) + "/"
                                    + currentdate.getDate()+ "/" 
                                    + currentdate.getFullYear();
               
                  var hours = currentdate.getHours();
                  var minutes = currentdate.getMinutes();
                  var sec = currentdate.getSeconds();
                  var ampm = hours >= 12 ? 'PM' : 'AM';
                  hours = hours % 12;
                  hours = hours ? hours : 12; // the hour '0' should be '12'
                  minutes = minutes < 10 ? '0'+minutes : minutes;
                  var strTime = hours + ':' + minutes + ':' + sec ;//+ ' ' + ampm;
                  Qsdate=datetime;// + ' ' + strTime;
 $.ajax({
        url:"../Master/Default.aspx/getuserdetailval",
        data:"{}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(data) {
        var str=data.d;
        var arr = str.split(',');
         QDate=Qsdate;
         $('#hdn_date').val(QDate);
         QPidno=arr[1];
         QShift=arr[2];
         QOPERATOR=arr[3];
         $('#spn_partno').text(arr[4]);
         $('#hdn_partno').val(arr[4]);
         $('#hdn_pidno').val(arr[1]);
         $('#hdn_shift').val(arr[2]);
         $('#hdn_operation').val(arr[5]);
         $('#spn_machine').text(arr[6]);
         var cout=0;
         var tbl="<div style='margin-left:-486.5px;'> <table id='tblqualitysheet'  style='border: 0px solid black;border-collapse: collapse;background-color:#eefaff;' width='100%'><tr><td style='text-align:center;height:20pt;width:95px;' class='styleHDR'><span id='spn_date'>"+QDate+"</span></td><td style='border: 1px solid black;width:0px;'><input type='text' id='Text_pidno' style='width:88px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;' class='MrpTxtBox_dyn5' /></td><td style='text-align:center;height:10pt;width:48px;' class='styleHDR'><span id='spn_Shift'>"+QShift+"</span></td><td style='text-align:center;height:10pt;width:97px;' class='styleHDR'><span id='spn_opt'>"+QOPERATOR+"</span></td><td style='border: 1px solid black;'><input type='text' id='Textslno' style='width:41px;height: 15pt;border:none;background-color:#f7dff0;' class='specTxtbx' /></td><td style='border: 1px solid black;'><input type='text' id='Textheatcode' style='width:100px;height: 15pt;border:none;background-color:#f7dff0;' class='specTxtbx' /></td>";
            $.ajax({
            url:"../Master/Default.aspx/GetheaderQsTxtbx_header1",
            data:"{}",
            type:"POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(msg) {
             for(var k=0;k<msg.d.length;k++)
             {
                      Mrpval=(msg.d[k].Instrcount);
                      var newStr =msg.d[k].Instruments.replace(/\s+/g, '');
                     
                     if(msg.d[k].Cells!="" && msg.d[k].Cells!="0" && msg.d[k].Cells!=null)
                      {
                   
                                 if(msg.d[k].Frequency == "1/5 Parts")
                                 {
                                         for(var i=1;i<=Mrpval*2;i++)
                                          {
                                             tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="MrpTxtBox_dyn5"' ;
                                             if((tid% 5) == 0)
                                              {
                                                tbl+=' style="width:95px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                              }
                                              else
                                              {
                                               
                                                tbl+='disabled="disabled" style="width:95px;height: 15pt;background-color:gray;border:none;text-align:center;" /></td>';
                                              }
                                          }
                                          
                                    }
                                    else if(msg.d[k].Frequency  == "1/10 Parts")
                                     { 
                                             for(var i=1;i<=Mrpval*2;i++)
                                              {
                                                 tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="MrpTxtBox_dyn5"' ;
                                                 if((tid% 10) == 0)
                                                  {
                                                    tbl+=' style="width:95px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                                  }
                                                  else
                                                  {
                                                   
                                                    tbl+='disabled="disabled" style="width:95px;height: 15pt;background-color:gray;border:none;text-align:center;" /></td>';
                                                  }
                                              }
                                     }
                                     else if(msg.d[k].Frequency  == "1/15 Parts")
                                     {
                                            for(var i=1;i<=Mrpval*2;i++)
                                              {
                                                 tbl+='<td style="border: 1px solid black;"><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="MrpTxtBox_dyn5"' ;
                                                 if((tid% 15) == 0)
                                                  {
                                                    tbl+=' style="width:95px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                                  }
                                                  else
                                                  {
                                                   
                                                    tbl+='disabled="disabled" style="width:95px;height: 15pt;background-color:gray;border:none;text-align:center;" /></td>';
                                                  }
                                              }
                                      }
                                      else
                                      {
                                              var d=1;
                                              for(var i=1;i<=Mrpval*2;i++)
                                              {
                                                
                                                if(i % 2 ==1)
                                                {
                                                    d+=1;
                                                }
                                                else
                                                {
                                                }
                                                tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" style="width:95px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" class="MrpTxtBox_dyn" onblur="javascript:checkrange('+d+','+msg.d[k].Id+','+i+');"/></td>' ;
                                                mrgvalue++;
                                              }
                                        }
                        }
                        else
                        {
                       
                        if(msg.d[k].Cells == "" || msg.d[k].Cells =="0" || msg.d[k].Cells == null)
                        {
                            if(msg.d[k].Frequency == "1/5 Parts")
                                     {
                                         for(var i=1;i<=Mrpval;i++)
                                          {
                                            tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="RghTxtBox_dyn5"' ;
                                             if ((tid% 5) == 0)
                                              {
                                               
                                              tbl+=' style="width:197px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                              }
                                              else
                                              {
                                              tbl+='disabled="disabled"  style="width:197px;height: 15pt;background-color:gray;border:none" /></td>';
                                              }
                                          }
                                   }
                                  else if(msg.d[k].Frequency == "1/10 Parts")
                                  { 
                                          for(var i=1;i<=Mrpval;i++)
                                          {
                                             tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="RghTxtBox_dyn5"' ;
                                             if ((tid% 10) == 0)
                                              {
                                              tbl+=' style="width:197px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                              }
                                              else
                                              {
                                              tbl+='disabled="disabled"  style="width:197px;height: 15pt;background-color:gray;border:none" /></td>';
                                              }
                                          }
                                     }
                                    else if(msg.d[k].Frequency == "1/15 Parts")
                                    {
                                        for(var i=1;i<=Mrpval;i++)
                                        {
                                             tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="RghTxtBox_dyn5"' ;
                                             if ((tid% 15) == 0)
                                              {
                                              tbl+=' style="width:197px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                              }
                                              else
                                              {
                                              tbl+='disabled="disabled"  style="width:197px;height: 15pt;background-color:gray;border:none" /></td>';
                                              }
                                          }
                                    }
                                    else
                                    {
                                         for(var i=1;i<=Mrpval;i++)
                                          {
                                          cout+=1;
                                              tbl+='<td style="border: 1px solid black;" ><input  type="text" id="txt_'+msg.d[k].Id+''+i+'" style="width:197px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" class="RghTxtBox_dyn" onblur="javascript:changeothertab('+cout+','+msg.d[k].Id+','+i+');" /></td>' ;
                                              rghvalue++;
                                             
                                          }

                                    }
                        }
                                    
                        }
                       
             }
               tbl+="<td style='border: 1px solid black;'><input type='text' id='textcmt' style='width:95px;height: 15pt;border:none;' class='TxtBox_dyn9'/></td><td style='border: 1px solid black;width:97.5px;height: 15pt;' ><img src='../images/add.png'  alt='Submit'  id='btn_Save' style='margin-left:35px;cursor:pointer;' onclick='javascript:Save();'/></td></tr></table></div>";
                 $("#div_tab").html(tbl);
                  //$("#btn_Save").bind("click", Save);
                 
                  
            },
            error:function()
            {}
          });
         },
         error:function()
        {}
        });

               
                             
}
 function Save()
 {
 
    var dt= $('#hdn_date').val();
    var user=$('#spn_opt').text();
    var pid=$('#Text_pidno').val();
    var shift=$('#spn_Shift').text();
    $('#hdn_shift1').val(shift);
    $('#hdn_operator').val(user);
    var sno=$('#Textslno').val();
    var code=$('#Textheatcode').val();
    var cmt=$('#textcmt').val();
    var textvalues=dt+","+pid+","+shift+","+user+","+sno+","+code;
             $.ajax({
                        url:"../Master/Default.aspx/GetheaderQsTxtbx_header1",
                        data:"{}",
                        type:"POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(msg)
                        {
                             part=msg.d;
                             var avg="";
                             var tot=0;
                            var table = document.getElementById("tblqualitysheet");
                            var tblength=table.rows.length-1;
                            for(var k=0;k<=tblength;k++)
                            {
                                for(var c=0;c<msg.d.length;c++)
                                {
                                    var newStr =msg.d[c].Instruments.replace(/\s+/g, '');
                                   
                                    if(msg.d[c].Cells!="" && msg.d[c].Cells!=null && msg.d[c].Cells!="0")
                                    {
                                        for(var m=1;m<=(msg.d[c].Instrcount*2);m++)
                                        {
                                            if($('#txt_'+msg.d[c].Id+''+m+'').is(':disabled'))
                                            {   
                                                textvalues+=",";
                                            }
                                            else
                                            {
                                                var txt=$('#txt_'+msg.d[c].Id+''+m+'').val();
                                                if(txt=="")
                                                {
                                                    $('#txt_'+msg.d[c].Id+''+m+'').css( "background-color","pink" );
                                                    alert('ENTER '+msg.d[c].Instruments+' VALUE');
                                                    $('#txt_'+msg.d[c].Id+''+m+'').focus();
                                                    return;
                                                }
                                                else
                                                {
                                                    $('#txt_'+msg.d[c].Id+''+m+'').css( "background-color","#fff" );
                                                    textvalues+=","+txt;
                                                    tot=tot+parseFloat(txt);
                                                }
                                                if((m%2)==0)
                                                {
                                                    var tot1=parseFloat(tot)/parseFloat(2);
                                                    tot=0;
                                                    avg+=","+tot1;
                                                }
                                            }
                                            
                                        }
                                    }
                                    else
                                    {
                                        for(var m=1;m<=msg.d[c].Instrcount;m++)
                                        {
                                            if($('#txt_'+msg.d[c].Id+''+m+'').is(':disabled'))
                                            {   
                                                textvalues+=",";
                                            }
                                            else
                                            {
                                                var txt=$('#txt_'+msg.d[c].Id+''+m+'').val();
                                                if(txt=="")
                                                {
                                                   $('#txt_'+msg.d[c].Id+''+m+'').css( "background-color","pink" );
                                                   alert('ENTER '+msg.d[c].Instruments+' VALUE');
                                                   $('#txt_'+msg.d[c].Id+''+m+'').focus();
                                                   return;
                                                }
                                                else
                                                {
                                                    $('#txt_'+msg.d[c].Id+''+m+'').css( "background-color","#fff" );
                                                    textvalues+=","+txt;
                                                }
                                            }
                                            
                                        }
                                    }
                                }
                            }
                            var max=$('#hdn_max').val();
                            var min=$('#hdn_min').val();
                            var ymax1=$('#hdn_ymax').val();
                            var ymin1=$('#hdn_ymin').val();
                            textvalues+=","+cmt;
                            getversion1();
                                        showLayer();
                                        $.ajax({
                                        url:"../Master/Default.aspx/TxtbxSavevalues",
                                        data:"{'Texboxvalues':'"+textvalues+"','Average1':'"+avg+"','Max':'"+max+"','Min':'"+min+"','YMax':'"+ymax1+"','YMin':'"+ymin1+"'}",
                                        type:"POST",
                                        contentType: "application/json; charset=utf-8",
                                        dataType: "json",
                                        success: function(msg)
                                        {
                                                if(msg.d=="S")
                                                {
                                                 getotqty();
                                                 getmaxmin();
                                               //  showtxbx();
                                                 hideLayer();
                                                 exportoexcel(); 
                                                 showfixture();
                                                }
                                        },
                                        error:function()
                                        {}
                                        });
                        },
                        error:function()
                        {}
                 });
    
 }
function Chart()
{
document.getElementById("btn_chart").click();
}

function exportoexcel()
{

            var html = '';
            html += $("#div_data").html();
            html = $.trim(html);
            html = html.replace(/>/g, '&gt;');
            html = html.replace(/</g, '&lt;');
            $('#hdn_excel').val(html);
            
           
            document.getElementById("btn_excel").click();
            return false;

         //   $("#HdnValexceldata").val(html);
        //    document.getElementById("btn_export").click();
//         $.ajax({
//                        url:"../Master/Default.aspx/export",
//                        data:"{'Texboxvalues':'"+html+"'}",
//                        type:"POST",
//                        contentType: "application/json; charset=utf-8",
//                        dataType: "json",
//                        success: function(msg)
//                        {
//                       
//                            if(msg.d=="S")
//                            {
//                                hideLayer();
//                            }
//                                
//                        },
//                        error:function()
//                        {}
//                        });
                        
}


function headertextshow(part,operation,unit,cell)
{
    var tbl='<table style=" border-collapse: collapse;" width="100%"><tr style="background-color:#4C6C9F;border:solid 1px #fff;">';
    var ttbbl='<div style=""><table style=" border-collapse: collapse; width="100%" ><tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="style58" colspan="6" style="text-align:center; width:500px; background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;"><span>Instruments</span> </td>';
    $.ajax({
            url:"../Master/Default.aspx/GetadminheaderQsTxtbx_header",
            data:"{'Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
            type:"POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(msg) {
                  for(var i=0;i<msg.d.length;i++)
                  {
                    if(msg.d[i].Cells!=null  && msg.d[i].Cells!="0" && msg.d[i].Cells!="")
                    {
                       var width=parseInt(msg.d[i].Instrcount);
                       var col=parseInt(width)*(1);
                       var col1=parseInt(width)*(2);
                       width=parseInt(width)*(203);
                       var w='width:'+width+'px;';
                       tbl+='<td style="text-align:center; white-space:normal;margin-right:40px;height:16pt;color:#fff;border:solid 1.6px #fff;'+w+'" class="styleHDR"> <div style="border-bottom:1px solid #fff;"><span style="color:#FFE4C4;">' + msg.d[i].Headername + '</span></div><div><span span style="color:#FAF0E6;" id=span1_'+msg.d[i].id+'>' + msg.d[i].Instruments + '</span></div> </td>';
                       ttbbl+='<td  colspan='+col1+' style="text-align:center;white-space:normal;margin-right:40px;height:16pt;color:#fff;border:solid 1.6px #fff;'+w+'" class="styleHDR"> <div style="border-bottom:1px solid #fff;"><span style="color:#FFE4C4;">' + msg.d[i].Headername + '</span></div><div><span span style="color:#FAF0E6;" id=span1_'+msg.d[i].id+'>' + msg.d[i].Instruments + '</span></div> </td>';

                    }
                    else
                    {
                       var width=parseInt(msg.d[i].Instrcount);
                       var col=parseInt(width)*(1);
                       width=parseInt(width)*(201);
                       var w='width:'+width+'px;';
                       tbl+='<td  style="text-align:center; white-space:normal;margin-right:40px;height:16pt;color:#fff;border:solid 1.6px #fff;'+w+'" class="styleHDR"> <div style="border-bottom:1px solid #fff;"><span style="color:#FFE4C4;">' + msg.d[i].Headername + '</span></div><div><span span style="color:#FAF0E6;" id=span1_'+msg.d[i].id+'>' + msg.d[i].Instruments + '</span></div> </td>';
                       ttbbl+='<td colspan='+col+' style="text-align:center; white-space:normal;margin-right:40px; height:16pt;color:#fff;border:solid 1.6px #fff;'+w+'" class="styleHDR"> <div style="border-bottom:1px solid #fff;"><span style="color:#FFE4C4;">' + msg.d[i].Headername + '</span></div><div><span span style="color:#FAF0E6;" id=span1_'+msg.d[i].id+'>' + msg.d[i].Instruments + '</span></div> </td>';

                    }
                  }
                  tbl+='</tr></table>';
                  ttbbl+='</tr></table></div>';
                  $('#divheaderlabel').html(tbl);
                  $('#div_sheetheader').html(ttbbl);
            },
            error:function()
            {}
          });
}
function exituser()
{
//        $.ajax({
//                url:"../Master/Default.aspx/logout",
//                data:"{}",
//                type:"POST",
//                contentType: "application/json; charset=utf-8",
//                dataType: "json",
//                success: function(msg)
//                {
//             
//                    if (confirm("Are you sure want to Logout?"))
//                    {
//                        if(msg.d=="S")
//                        {
//                            window.location.href="../Home.aspx";
//                        }
//                   }
//                    return false;
//                },
//                error:function()
//                {}
//              });
    if (confirm("Are you sure want to Logout?"))
    {
        $.ajax({
            url:"../Master/Default.aspx/logout",
            data:"{}",
            type:"POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(msg)
            {
                window.location.href="../Home.aspx";
                return false;
            },
            error: function (xhr, ajaxOptions, thrownError) {
//            alert(xhr.status);
//            alert(thrownError);
//            var err = eval("(" + xhr.responseText + ")");
//            alert(err.Message);
            }
          });
        return false;
    }
}


function showuserheader()
{

 $.ajax({
                url:"../Master/Default.aspx/userdata",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg!=null && msg!="")
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
                            if(msg.d[i].name!=null && msg.d[i].name!="")
                            {
                                // $('#spn_machinename').text(msg.d[i].Machinename);  
                                 $('#sp_logdate').text(msg.d[i].date);  
                                 $('#sp_logtimr').text(msg.d[i].time);  
                                 $('#sp_username').text(msg.d[i].name);  
                                  showmachinestatus();
                            }
                            else
                            {
                                var url="../Home.aspx";
                                window.top.location.href=url;
                            }
                        }
                    }
                },
                error:function()
                {}
              });
}
function  getversion()
{
$.ajax({
                url:"../Master/Default.aspx/getsheetversion",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                
                    if(msg!=null && msg!="")
                    {
                        $('#spn_version').text(msg.d);
                    }
                },
                error:function()
                {}
              });
}
function  getversion1()
{
        var part=$('#hdn_partno1').val();
        var operation=$('#hdn_operation').val();
        var unit=$('#hdn_unit').val();
        var cell=$('#hdn_cell').val();
    var version=$('#spn_version').text();
    var s='';
$.ajax({
                url:"../Master/Default.aspx/get_adminsheetversion",
                data:"{'Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                
                    if(msg!=null && msg!="")
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
                            if(msg.d[i].filename==null || msg.d[i].filename=="")
                            {
                                $('#spn_filename').text('File Name Not Found');
                            }
                            else
                            {
                                $('#spn_filename').text(msg.d[i].filename);
                            }
                            $('#spn_createby').text(msg.d[i].creatby);
                            if(version==msg.d[i].version || version=="")
                            {
                                $('#spn_version').text(msg.d[i].version);
                                $('#spn_createdate').text(msg.d[i].date);
                            } 
                            else
                            {
                                 $('#spn_version').text(msg.d[i].version);
                                 $('#spn_createdate').text(msg.d[i].date);
                                 var prt=$('#spn_partno').text();
                                 var ope=$('#hdn_operation').val();
                                 $('#spn_msg').text('Quality Sheet Version Updated for');
                                 $('#spn_parthome').text(prt +' [ '+ope+' ]');
                                 var modal = document.getElementById('myModal');
                                 modal.style.display = "block";
                             }
                        }
                       
                        
                    }
                },
                error:function()
                {}
              });
           
}
 function loadevent()
 {     
        headertextshow();
        showuserheader();
        getotqty();
        getinstcount();
        get_designvalue();
        ////
        showfixture();
        getversion();
        getversion1();
 }
 function checkrange(id,name,dd)
 {
    var ymax='';
    var ymin='';
    var count=parseInt(id)-parseInt(1);
    var mmax=rmax[count];
    var mmin=rmin[count];
    var values=$('#txt_'+name+''+dd+'').val();
    var yymean=ymean[count];
    var maxmin=parseFloat(mmax)-parseFloat(mmin);
    var maxminper=maxmin*0.6;
    var div=parseFloat(maxminper)/parseFloat(2);
    var maxy=parseFloat(yymean)+parseFloat(div);
    var miny=parseFloat(yymean)-parseFloat(div);
    var n = maxy.toString(); 
    var n1 = miny.toString(); 
    n=n.substring(0,6);
    n1=n1.substring(0,6);
    if(values > parseFloat(mmax) || values < parseFloat(mmin))
    {
        $('#txt_'+name+''+dd+'').css({"background-color": "red"});
    }
    else if(values >= parseFloat(n1) && values <= parseFloat(n))
    {
         $('#txt_'+name+''+dd+'').css({"background-color": "yellow"});
    }
    else
    {
          $('#txt_'+name+''+dd+'').css({"background-color": "green"});
    }
 }
 function changeothertab(id,name,dd)
 {
     var values=$('#txt_'+name+''+dd+'').val();
     var _count=parseInt(id);
     var oth=other[_count];
     values=parseFloat(values);
     if(values > parseFloat(oth))
     {
      $('#txt_'+name+''+dd+'').css({"background-color": "red"});
        
     }
     else
     {
        $('#txt_'+name+''+dd+'').css({"background-color": "#f7dff0"});
     }
 }
 function checkuprange(id,name,dd)
 {
    var ymax='';
    var ymin='';
    var count=parseInt(dd);
    var mmax=rmax[count];
    var mmin=rmin[count];
    var values=$('#txt_value_'+id+''+name+'').val();
    var yymean=ymean[count];
    var maxmin=parseFloat(mmax)-parseFloat(mmin);
    var maxminper=maxmin*0.6;
    var div=parseFloat(maxminper)/parseFloat(2);
    var maxy=parseFloat(yymean)+parseFloat(div);
    var miny=parseFloat(yymean)-parseFloat(div);
    var n = maxy.toString(); 
    var n1 = miny.toString(); 
    n=n.substring(0,6);
    n1=n1.substring(0,6);
    if(values > parseFloat(mmax) || values < parseFloat(mmin))
    {
        $('#txt_value_'+id+''+name+'').css({"background-color": "red"});
    }
    else if(values >= parseFloat(n1) && values <= parseFloat(n))
    {
         $('#txt_value_'+id+''+name+'').css({"background-color": "yellow"});
    }
    else
    {
          $('#txt_value_'+id+''+name+'').css({"background-color": "green"});
    }
 }
 function getmasterlinkpages()
{
 $.ajax({
                url:"../Master/Default.aspx/getmasterlink",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!=null && msg.d!="")
                    {
                    var tbl='';
                        for(var i=0;i<msg.d.length;i++)
                        {
                           var op='';
                           if(msg.d[i].Operation=='1' || msg.d[i].Operation=='2')
                           {
                            op='Operation '+msg.d[i].Operation;
                           }
                           else
                           {
                            op=msg.d[i].Operation;
                           }
                         var width=$('#hdn_liwidth').val();
                           var partno=msg.d[i].Partno;
                           var cell=msg.d[i].Cell;
                           tbl+="<li style='width:"+width+"px;'><a href='../DYNSheets/AdminQulitySheet.aspx?partno="+msg.d[i].Partno+"&operation="+msg.d[i].Operation+"&unit=MBU&cell="+msg.d[i].Cell+"'>"+msg.d[i].Partno+" - "+op+"</a></li>";
                        }
                        $('#ul_productiondata').html(tbl);
                    }
                },
                error:function()
                {}
              });
}
function getadminmachine(cell)
{
var dept=cell;
$.ajax({
        url:"../Master/Default.aspx/getmachinename",
        data:"{'dept':'"+dept+"'}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
        
            $("select[id$='ddl_adminmach']").get(0).options.length = 0;
            $("select[id$='ddl_adminmach']").get(0).options[0] = new Option("--- Select Machine ---", "0");
            part=msg.d;
            comma=part.split(",");
            for(var count=0;count<comma.length;count++)
            {
                if(comma[count]=="")
                {
                }
                else
                {
                    $("select[id$='ddl_adminmach']").get(0).options[$("select[id$='ddl_adminmach']").get(0).options.length] = new Option(comma[count], comma[count]);
                }
            }
            
            var M=$("input[id$='hdn_mach']").val();
            if(M!="")
            {
                $("select[id$='ddl_adminmach']").val(M);
            }
            
            part=null;
            comma=null;
            
      },
        error:function()
        {}
      });
}
              
function ShowDialog(modal)
   {
      $("#overlay").show();
      $("#dialog").fadeIn(300);

      if (modal)
      {
         $("#overlay").unbind("click");
      }
      else
      {
         $("#overlay").click(function (e)
         {
            HideDialog();
         });
      }
   }

   function HideDialog()
   {
      $("#overlay").hide();
      $("#dialog").fadeOut(300);
   } 
   $(function()
   {
    $('#td_search').click(function()
    {
         ShowDialog(false);
       //  e.preventDefault();
    });
   });
   $(function()
   {
      $("#btnClose").click(function (e)
      {
         HideDialog();
        // e.preventDefault();
      });
    });
   
   
      
function validatesearchQS()
{
    if(!valsrchdate())return false
    if(!valsrchshift())return false
    if(!valsrchmach())return false
    if(!valsrchoperator())return false
    return true;
}

function valsrchdate()
{
     var date=$("input[id$='txt_date']").val();
     if(date=="" || date==null )
     {
        alert("Select Date");
        return false;
     }
     else
     {
       $("input[id$='hdn_date1']").val(date);
       return true;
     }
} 
function valsrchshift()
{
     var shift=$("select[id$='ddl_adminshift']").val();
     if(shift=="" || shift==null || shift=="0")
     {
        alert("Select Shift");
        return false;
     }
     else
     {
       $("input[id$='hdn_shift1']").val(shift);
       return true;
     }
} 
function valsrchmach()
{
     var mach=$("select[id$='ddl_adminmach']").val();
     if(mach=="" || mach==null || mach=="0")
     {
        alert("Select Machine");
        return false;
     }
     else
     {
       $("input[id$='hdn_mach1']").val(mach);
       return true;
     }
}
function valsrchoperator()
{
     var operator=$("select[id$='ddl_adminoperator']").val();
     if(operator=="" || operator==null || operator=="0")
     {
        alert("Select Operator");
        return false;
     }
     else
     {
       $("input[id$='hdn_operator']").val(operator);
       return true;
     }
}
   $(function()
   {
        $('#btn_searchsheet').click(function()
        {
            var res=validatesearchQS();
       
            if(res==true)
            {
                getsearchmax();
            }
        });
   });
 
   function getsearchmax()
   {
            var d=$('#txt_date').val();
            var part=$('#hdn_partno1').val();
            var operation=$('#hdn_operation').val();
            var unit=$('#hdn_unit').val();
            var cell=$('#hdn_cell').val();
            var shift=$('#ddl_adminshift').val();
            var mach=$('#ddl_adminmach').val();
         $('#spn_machine').text(mach);
         $('#spn_mach1').text(mach);
            var max='';
            $.ajax({
                url:"../Master/Default.aspx/Get_adminmaxmin",
                data:"{'Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                
                    for(var m=0;m<msg.d.length;m++)
                    {
                        max+=","+ msg.d[m].Max+","+msg.d[m].Min+","+msg.d[m].Cellvalue;
                    }
                     MaxMin=max.split(",");
                    showsearchlbl(MaxMin,part,operation,unit,cell,d,shift,mach);
                },
                error:function()
                {}
              });
   }
   function showsearchlbl(MaxMin,part,operation,unit,cell,d,shift,mach)
   {
    var minmax=[];
    minmax=MaxMin;
$('#hdn_shift1').val(shift);
$('#hdn_operator').val($('#ddl_adminoperator').val());
$('#hdn_date1').val($('#txt_date').val());
$('#hdn_mach1').val(mach);
        var tot=$('#hdn_instcount').val();
        $.ajax({
                url:"../Master/Default.aspx/ReadadminExistinsearchValues",
               data:"{'Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"','Date':'"+d+"','Shift':'"+shift+"','Machine':'"+mach+"','Operator':'"+$('#hdn_operator').val()+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg!=null && msg!="")
                    {
                        var first=1;
                        var time=1;
                        var edit=1;
                        var cmt=1;
                        var marphs=$('#hdn_marph').val();
                        var marphs1=$('#hdn_marph').val();
                          if(marphs1=="")
                          {
                           marphs1="0";
                          }
                          if(marphs=="")
                          {marphs="0";
                          }
                          
                        marphs=parseInt(5)+parseInt(marphs*2);
                        var total=parseInt(marphs)+parseInt(tot);
                        cmt=cmt+parseInt(total);
                        time=time+cmt;
                        edit=edit+time;
                        first=first+cmt;
                        var rowid=1;

                        var tbl="<div id='div_adminscroll' style='margin-left:-487px;'><table id='tb_label'  style='border: 0px solid black;border-collapse: collapse;background-color:#eefaff;'>";
                        var _tbl="<div><table id='tb_label' width='' style='border: 0px solid black;border-collapse: collapse;margin-left: -551px;background-color:#eefaff;'>";
                        for(var i=0;i<msg.d.length;i++)
                        {
                                var _cellval=0;
                                var _cellval1=0;
                                 var _m=1;
                                 var _m1=1;
                                 var reject='';
//                                $('#hdn_arrylength').val(msg.d[i].arr_val.length);
                                $('#hdn_arrylength').val(msg.d.length);
                                tbl+="<tr style=''><td style='border:none;'><div style='border:none;margin-top:-2px;display:block;'id='div_edit_"+i+"'><table style='border:none;border-collapse: collapse;'><tr style='border:none;height:30px;'><td style='text-align:center;height:10pt;width:95px;' class='styleHDR'><span id='spn_date'>"+msg.d[i].arr_val[0]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:93px;' class='styleHDR'><span id='spn_pidno'>"+msg.d[i].arr_val[1]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:47px;' class='styleHDR'><span id='spn_Shift'>"+msg.d[i].arr_val[2]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:98px;' class='styleHDR'><span id='spn_opt'>"+msg.d[i].arr_val[3]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:50px;'  class='styleHDR'><span id='Textslno'>"+msg.d[i].arr_val[4]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:101.4px;'  class='styleHDR'><span id='Textheatcode'>"+msg.d[i].arr_val[5]+"</span></td>";
                                _tbl+="<tr><td style='border:none;'><div style='border:none;margin-top:-2px;display:block;'id='div_edit_"+i+"'><table style='border:none;border-collapse: collapse;'><tr style='border:none;'><td style='text-align:center;height:10pt;width:98px;' class='styleHDR'><span id='spn_date'>"+msg.d[i].arr_val[0]+"</span></td>";
                                _tbl+="<td style='text-align:center;height:10pt;width:88px;' class='styleHDR'><span id='spn_pidno'>"+msg.d[i].arr_val[1]+"</span></td>";
                                _tbl+="<td style='text-align:center;height:10pt;width:75px;' class='styleHDR'><span id='spn_Shift'>"+msg.d[i].arr_val[2]+"</span></td>";
                                _tbl+="<td style='text-align:center;height:10pt;width:78px;' class='styleHDR'><span id='spn_opt'>"+msg.d[i].arr_val[3]+"</span></td>";
                                _tbl+="<td style='text-align:center;height:10pt;width:75px;'  class='styleHDR'><span id='Textslno'>"+msg.d[i].arr_val[4]+"</span></td>";
                                _tbl+="<td style='text-align:center;height:10pt;width:85px;'  class='styleHDR'><span id='Textheatcode'>"+msg.d[i].arr_val[5]+"</span></td>";
                                 var d=1;
                                 
                                  for (var k=6;k<=total;k++)
                                {
                                    _cellval+=3;
                                    var _instcount=minmax[_cellval];
                                    if(_instcount!="" && _instcount!="0" && _instcount!=null)
                                    {
                                    
                                        var _max=minmax[_m];
                                        _m+=1;
                                        var _min=minmax[_m];
                                         _m+=2;
                                         d+=1;
                                         for(var m=0;m<_instcount;m++)
                                         {
                                            var val=k+m;
                                            var values=parseFloat(msg.d[i].arr_val[k+m]);
                                            var ymax='';
                                            var sty='';
                                            var ymin='';
                                            var count=parseInt(d)-parseInt(1);
                                            var mmax=rmax[count];
                                            var mmin=rmin[count];
                                            var yymean=ymean[count];
                                            var maxmin=parseFloat(mmax)-parseFloat(mmin);
                                            var maxminper=maxmin*0.6;
                                            var div=parseFloat(maxminper)/parseFloat(2);
                                            var maxy=parseFloat(yymean)+parseFloat(div);
                                            var miny=parseFloat(yymean)-parseFloat(div);
                                            var n = maxy.toString(); 
                                            var n1 = miny.toString(); 
                                            n=n.substring(0,6);
                                            n1=n1.substring(0,6);
                                            if(values > parseFloat(mmax) || values < parseFloat(mmin))
                                            {
                                                sty="background-color:red";
                                            }
                                            else if(values >= parseFloat(n1) && values <= parseFloat(n))
                                            {
                                                
                                                 sty="background-color:yellow";
                                            }
                                            else
                                            {
                                                sty="background-color:green";
                                            }
                                             tbl+='<td style="text-align:center;width:100px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k+m]+ '</td>';
                                             _tbl+='<td style="text-align:center;width:101.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k+m]+ '</td>';
                                         }
                                         
                                         k+=1;
                                    }
                                    else
                                    {
                                        var _max=minmax[_m];
                                        var _min=minmax[_m + 1];
                                        var values1=parseFloat(msg.d[i].arr_val[k]);
                                        var vis_val=msg.d[i].arr_val[k];
                                        if(values1 > parseFloat(_max) || values1 < parseFloat(_min)|| vis_val == "not ok"|| vis_val =="notok" || vis_val =="NOT OK" || vis_val =="NOTOK")
                                        {
                                            var sty='background-color:red;'
                                        }
                                        else if(vis_val =="-")
                                        {
                                            var sty='background-color:orange;'
                                        }
                                        else
                                        {
                                            var sty='background-color:none;'
                                        }
                                        if(msg.d[i].arr_val[k]=="None")
                                        {
                                            tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR"></td>';
                                            _tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k]+ '</td>';
                                        }
                                        else
                                        {
                                            tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k]+ '</td>';
                                            _tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k]+ '</td>';
                                        }
                                        _m+=3;
                                    }
                                    
                                        
                                }
                                
//                                for (var k=6;k<=marphs;k++)
//                                {
//                                         var _max=minmax[_m];
//                                         _m+=1;
//                                         var _min=minmax[_m];
//                                             
//                                         var values=parseFloat(msg.d[i].arr_val[k]);
//                                          var ymax='';
//                                           var sty='';
//                                            var ymin='';
//                                            if(k % 2 ==0)
//                                            {
//                                               
//                                                d+=1;
//                                            }
//                                            var count=parseInt(d)-parseInt(1);
//                                            var mmax=rmax[count];
//                                            var mmin=rmin[count];
//                                            var yymean=ymean[count];
//                                            var maxmin=parseFloat(mmax)-parseFloat(mmin);
//                                            var maxminper=maxmin*0.6;
//                                            var div=parseFloat(maxminper)/parseFloat(2);
//                                            var maxy=parseFloat(yymean)+parseFloat(div);
//                                            var miny=parseFloat(yymean)-parseFloat(div);
//                                            var n = maxy.toString(); 
//                                            var n1 = miny.toString(); 
//                                            n=n.substring(0,6);
//                                            n1=n1.substring(0,6);
//                                            if(values > parseFloat(mmax) || values < parseFloat(mmin))
//                                            {
//                                                sty="background-color:red";
//                                            }
//                                            else if(values >= parseFloat(n1) && values <= parseFloat(n))
//                                            {
//                                                
//                                                 sty="background-color:yellow";
//                                            }
//                                            else
//                                            {
//                                                sty="background-color:green";
//                                            }
//                                         
//                                             tbl+='<td style="text-align:center;width:101.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k]+ '</td>';
//                                             _tbl+='<td style="text-align:center;width:131px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k]+ '</td>';
//                                             if(k%2==1)
//                                             {
//                                                 _m+=1;
//                                             }
//                                             else
//                                             {
//                                                 _m+=-1;
//                                             }
//                                        
//                                }
//                                for (var l=k;l<=total;l++)
//                                {
//                                     var _max=minmax[_m];
//                                     var values1=parseFloat(msg.d[i].arr_val[l]);
//                                     if(values1 > parseFloat(_max))
//                                     {
//                                        var sty='background-color:red;'
//                                     }
//                                     else
//                                     {
//                                         var sty='background-color:none;'
//                                     }
//                                     if( msg.d[i].arr_val[l]=="None")
//                                     {
//                                        tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR"></td>';
//                                     }
//                                     else
//                                     {
//                                        tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[l]+ '</td>';
//                                     }
//                                    
//                                    _tbl+='<td style="text-align:center;width:261.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[l]+ '</td>';
//                                   _m+=2;
//                                }
                                for (var a=k;a<=cmt;a++)
                                {
                                  tbl+='<td style="text-align:center;width:100px;" class="styleHDR">' + msg.d[i].arr_val[a]+ '</td>';
                                  _tbl+='<td style="text-align:center;width:130px;" class="styleHDR">' + msg.d[i].arr_val[a]+ '</td>';
                                }
                                for (var n=a;n<=time;n++)
                                {
                                  tbl+='<td style="text-align:center;width:100px;" class="styleHDR">' + msg.d[i].arr_val[n]+ '</td>';
                                  _tbl+='<td style="text-align:center;width:130px;" class="styleHDR">' + msg.d[i].arr_val[n]+ '</td>';
                                }
                                for (var x=n;x<=edit;x++)
                                {
                                  tbl+='<td style="border: 1px solid black;width:97px;"><input type="image" src="../images/Editnew.jpg"  id="divedit_'+i+'" alt="Edit"   style="width:25px;margin-left:35px;" onclick="javascript:show1('+i+');"/></td>';
                                  //tbl+='<td style="border: 1px solid black;width:97px;"></td>';
                                }
                                tbl+="</tr></table></div>";
                                _tbl+="</tr></table></div>";
                                tbl+="<div style='border:none;margin-top:-2px;display:none;'id='div_update_"+i+"'><table style='border:none;border-collapse: collapse;background-color:#fff;'><tr style='border:none;height:30px;'><td style='text-align:center;height:10pt;width:95px;' class='styleHDR'><span id='spn_date'>"+msg.d[i].arr_val[0]+"</span></td>";
                                //tbl+="<td style='text-align:center;height:10pt;width:93px;' class='styleHDR'><span id='spn_pidno'>"+msg.d[i].arr_val[1]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:93px;;'  class='styleHDR'><input type='text' id='spn_pidno"+i+"' style='height:10pt;width:93px;border:none;text-align:center;' class='RghTxtBox_dyn' value=" +msg.d[i].arr_val[1]+ "></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:47px;' class='styleHDR'><span id='spn_Shift'>"+msg.d[i].arr_val[2]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:98px;' class='styleHDR'><span id='spn_opt'>"+msg.d[i].arr_val[3]+"</span></td>";
                                //tbl+="<td style='text-align:center;height:10pt;width:50px;'  class='styleHDR'><span id='Textslno'>"+msg.d[i].arr_val[4]+"</span></td>";

                                tbl+="<td style='text-align:center;height:10pt;width:50px;'  class='styleHDR'><input type='text' id='Textslno"+i+"' style='height:10pt;width:50px;border:none;text-align:center;' class='RghTxtBox_dyn' value=" +msg.d[i].arr_val[4]+ "></td>";
                                //tbl+="<td style='text-align:center;height:10pt;width:98px;'  class='styleHDR'><span id='Textheatcode'>"+msg.d[i].arr_val[5]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:104.5px;'  class='styleHDR'><input type='text' id='Textheatcode"+i+"' style='height:10pt;width:98px;border:none;text-align:center;' class='RghTxtBox_dyn' value=" +msg.d[i].arr_val[4]+ "></td>";
                                var d1=1;
                                
                                for (var k=6;k<=total;k++)
                                {
                                    _cellval1+=3;
                                    var _instcount1=minmax[_cellval1];
                                    if(_instcount1!="" && _instcount1!="0" && _instcount1!=null)
                                    {
                                    
                                         var _max=minmax[_m1];
                                         _m1+=1;
                                         var _min=minmax[_m1];
                                         _m1+=2;
                                         d1+=1;
                                          for(var m=0;m<_instcount;m++)
                                         {
                                         
                                            var val=k+m
                                             var values=parseFloat(msg.d[i].arr_val[val]);
                                             var ymax='';
                                               var sty='';
                                                var ymin='';
//                                                if(k % 2 ==0)
//                                                {
//                                                   
//                                                    d1+=1;
//                                                }
                                                var count=parseInt(d1)-parseInt(1);
                                                var mmax=rmax[count];
                                                var mmin=rmin[count];
                                                var yymean=ymean[count];
                                                var maxmin=parseFloat(mmax)-parseFloat(mmin);
                                                var maxminper=maxmin*0.6;
                                                var div=parseFloat(maxminper)/parseFloat(2);
                                                var maxy=parseFloat(yymean)+parseFloat(div);
                                                var miny=parseFloat(yymean)-parseFloat(div);
                                                var n = maxy.toString(); 
                                                var n1 = miny.toString(); 
                                                n=n.substring(0,6);
                                                n1=n1.substring(0,6);
                                                if(values > parseFloat(mmax) || values < parseFloat(mmin))
                                                {
                                                    sty="background-color:red";
                                                    reject='1';
                                                }
                                                else if(values >= parseFloat(n1) && values <= parseFloat(n))
                                                {
                                                    
                                                     sty="background-color:yellow";
                                                }
                                                else
                                                {
                                                    sty="background-color:green";
                                                }
                                                  tbl+='<td style="text-align:center;width:70px;'+sty+'" class="styleHDR"><input type="text" id="txt_value_'+val+''+i+'"  style="width:95px;height: 15pt;border:none;text-align:center;'+sty+'" class="MrpTxtBox_dyn" value=' + msg.d[i].arr_val[val]+ ' onblur="javascript:checkuprange('+val+','+i+','+count+');"></td>';
                                           }
                                           k+=1;
//                                              if(k%2==1)
//                                             {
//                                                 _m1+=1;
//                                             }
//                                             else
//                                             {
//                                                 _m1+=-1;
//                                             }
                                        }
                                        else
                                        {
                                        var count1=0;
                                            if(msg.d[i].arr_val[k]!=null && msg.d[i].arr_val[k]!="")
                                            {
                                                count1+=1;
                                                 var _max=minmax[_m1];
                                                  var _min=minmax[_m1 + 1];
                                                 var values1=parseFloat(msg.d[i].arr_val[k]);
                                                 var vis_val=msg.d[i].arr_val[k];
                                                 if(values1 > parseFloat(_max) || values1 < parseFloat(_min) || vis_val == "not ok"|| vis_val =="notok" || vis_val =="NOT OK" || vis_val =="NOTOK")
                                                 {
                                                    var sty='background-color:red;'
                                                    reject='1';
                                                 }
                                                 else if(vis_val =="-")
                                                 {
                                                   var sty='background-color:orange;'
                                                 }
                                                 else
                                                 {
                                                     var sty='background-color:none;'
                                                 }
                                                 if(msg.d[i].arr_val[k]=="None")
                                                 {
                                                   tbl+='<td style="text-align:center;width:205.5px;'+sty+'" class="styleHDR"><input type="text"  id="txt_value_'+k+''+i+'" style="width:195px;height: 20pt;border:none;text-align:center;'+sty+'" class="RghTxtBox_dyn" value="" disabled="disabled"></td>';
                                                 }
                                                 else{
                                                   tbl+='<td style="text-align:center;width:205px;'+sty+'" class="styleHDR"><input type="text"  id="txt_value_'+k+''+i+'" style="width:155px;height: 20pt;border:none;text-align:center;'+sty+'" class="RghTxtBox_dyn" value=' + msg.d[i].arr_val[k]+ '></td>';
                                                   }
                                                   _m1+=3;
                                            }
                                            else
                                            {
                                                tbl+='<td style="text-align:center;width:205.5px" class="styleHDR"><input type="text"  id="txt_value_'+k+''+i+'" style="width:155px;height: 15pt;border:none;text-align:center;" class="RghTxtBox_dyn" value="" disabled="disabled"></td>';
                                            }
                                        }
                                }
                                
//                                for (var k=6;k<=marphs;k++)
//                                {
//                                         var _max=minmax[_m1];
//                                         _m1+=1;
//                                         var _min=minmax[_m1];
//                                         var values=parseFloat(msg.d[i].arr_val[k]);
//                                         var ymax='';
//                                           var sty='';
//                                            var ymin='';
//                                            if(k % 2 ==0)
//                                            {
//                                               
//                                                d1+=1;
//                                            }
//                                            var count=parseInt(d1)-parseInt(1);
//                                            var mmax=rmax[count];
//                                            var mmin=rmin[count];
//                                            var yymean=ymean[count];
//                                            var maxmin=parseFloat(mmax)-parseFloat(mmin);
//                                            var maxminper=maxmin*0.6;
//                                            var div=parseFloat(maxminper)/parseFloat(2);
//                                            var maxy=parseFloat(yymean)+parseFloat(div);
//                                            var miny=parseFloat(yymean)-parseFloat(div);
//                                            var n = maxy.toString(); 
//                                            var n1 = miny.toString(); 
//                                            n=n.substring(0,6);
//                                            n1=n1.substring(0,6);
//                                            if(values > parseFloat(mmax) || values < parseFloat(mmin))
//                                            {
//                                                sty="background-color:red";
//                                                reject='1';
//                                            }
//                                            else if(values >= parseFloat(n1) && values <= parseFloat(n))
//                                            {
//                                                
//                                                 sty="background-color:yellow";
//                                            }
//                                            else
//                                            {
//                                                sty="background-color:green";
//                                            }
//                                              tbl+='<td style="text-align:center;width:101.5px;'+sty+'" class="styleHDR"><input type="text" id="txt_value_'+k+''+i+'"  style="width:95px;height: 15pt;border:none;text-align:center;'+sty+'" class="MrpTxtBox_dyn" value=' + msg.d[i].arr_val[k]+ ' onblur="javascript:checkuprange('+k+','+i+','+count+');"></td>';
//                                              if(k%2==1)
//                                             {
//                                                 _m1+=1;
//                                             }
//                                             else
//                                             {
//                                                 _m1+=-1;
//                                             }
//                                              
//                                }
//                                for (var l=k;l<=total;l++)
//                                {
//                                    if(msg.d[i].arr_val[l]!=null && msg.d[i].arr_val[l]!="")
//                                    {
//                                         var _max=minmax[_m1];
//                                         var values1=parseFloat(msg.d[i].arr_val[l]);
//                                         if(values1 > parseFloat(_max))
//                                         {
//                                            var sty='background-color:red;'
//                                            reject='1';
//                                         }
//                                         else
//                                         {
//                                             var sty='background-color:none;'
//                                         }
//                                         if(msg.d[i].arr_val[l]=="None")
//                                         {
//                                            tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR"><input type="text"  id="txt_value_'+l+''+i+'" style="width:195px;height: 20pt;border:none;text-align:center;'+sty+'" class="RghTxtBox_dyn" value="" disabled="disabled"></td>';
//                                         }
//                                         else
//                                         {
//                                            tbl+='<td style="text-align:center;width:205px;'+sty+'" class="styleHDR"><input type="text"  id="txt_value_'+l+''+i+'" style="width:155px;height: 20pt;border:none;text-align:center;'+sty+'" class="RghTxtBox_dyn" value=' + msg.d[i].arr_val[l]+ '></td>';
//                                         }
//                                           
//                                           _m1+=2;
//                                    }
//                                    else
//                                    {
//                                       tbl+='<td style="text-align:center;width:101.3px" class="styleHDR"><input type="text"  id="txt_value_'+l+''+i+'" style="width:50px;height: 15pt;border:none;text-align:center;" class="RghTxtBox_dyn" value="" disabled="disabled"></td>';
//                                    }
//                                     
//                                }
                                for (var a=k;a<=cmt;a++)
                                {
                                  tbl+='<td style="text-align:center;width:100px;" class="styleHDR"><input type="text" id="txt_value_'+a+''+i+'" style="width:97px;height: 15pt;border:none;text-align:center;" class="TxtBox_dyn9" value=' + msg.d[i].arr_val[a]+ '></td>';
                                }
                                for (var n=a;n<=time;n++)
                                {
                                  tbl+='<td style="text-align:center;width:100px;" class="styleHDR"><span id="span_value_'+a+''+i+'" style="width:97px;height: 15pt;border:none;text-align:center;" class="TxtBox_dyn9" >' + msg.d[i].arr_val[n]+ ' </span></td>';
                                }
                                for (var x=n;x<=edit;x++)
                                {
                               
                                    var id=msg.d[i].arr_val[x];
                                    //tbl+='<td style="border: 1px solid black;width:99px;"><div align="center" style="margin-left:20px;" id="update_'+i+'"><table><tr><td style="width:50px;"><input type="image" src="../images/update.jpg"   alt="Edit" class="inputClass"  style="width:25px;" onclick="javascript:update('+msg.d[i].arr_val[x]+','+i+','+marphs1+','+tot+','+msg.d[i].arr_val[1]+');"/></td><td style="width:50px;"><input type="image" src="../images/Delete.png"   alt="Edit" class="inputClass"  style="width:25px;" onclick="javascript:Cancel('+i+');"/></td></tr></table></div></td>';
                                    tbl+='<td style="border: 1px solid black;width:95px;"><div align="center" style="margin-left:20px;" id="update_'+i+'"><table><tr><td style="width:50px;"><input type="image" src="../images/update.jpg"   alt="Edit" class="inputClass"  style="width:25px;" onclick="javascript:update1('+msg.d[i].arr_val[x]+','+i+','+marphs1+','+tot+');"/></td><td style="width:50px;"><input type="image" src="../images/Delete.png"   alt="Edit" class="inputClass"  style="width:25px;" onclick="javascript:Cancel('+i+');"/></td></tr></table></div></td>';
                                    
                                     $.ajax({
                                            url:"../Master/Default.aspx/UpdateadminRejectValues",
                                            data:"{'ID':'"+id+"','Reject':'"+reject+"','Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"'}", 
                                            type:"POST",
                                            contentType: "application/json; charset=utf-8",
                                            dataType: "json",
                                            success: function(msg)
                                            {
                                                if(msg.d=="S")
                                                {
                                                   
                                                }
                                            },
                                            error:function()
                                            {}
                                          });
                                }
                                tbl+="</tr></table></div>";
                                tbl+="</td></tr>";
                                rowid+=1;
                      }
                        tbl+="</table></div>";
                        _tbl+="</table></div>";
                        $("#div_lbl").html(tbl);
                        //jQuery('#div_adminscroll').css({"overflow-y": "scroll","height":"500px"});
                        $("#div_lbl1").html(_tbl);
                        var table=document.getElementById("tb_label");
                        tid=table.rows.length;
                        $('#hdnrowid').val(tid);
                        getsrhotqty(); 
                        HideDialog();
                        if(excel== 1)
                        {
                            exportoexcel(); 
                        }
                    }
                    else
                    {
                   
                         //showtxbx();
                    }
                },
                error:function()
                {}
              });
   }
function update1(id,r,marphs,tott)
{

var d=$('#txt_date').val();
var part=$('#hdn_partno1').val();
var operation=$('#hdn_operation').val();
var unit=$('#hdn_unit').val();
var cell=$('#hdn_cell').val();
var shift=$('#ddl_adminshift').val();
var mach=$('#ddl_adminmach').val();
$('#spn_machine').text(mach);
$('#spn_mach1').text(mach);
var max='';
$.ajax({
    url:"../Master/Default.aspx/Get_adminmaxmin",
    data:"{'Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
    type:"POST",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function(msg)
    {
    
        for(var m=0;m<msg.d.length;m++)
        {
            max+=","+ msg.d[m].Max+","+msg.d[m].Min+","+msg.d[m].Cellvalue;
        }
         MaxMin=max.split(",");
         
        var minmax=[];
        minmax=MaxMin;              
        $('#hdn_operation').val($('#hdn_operation').val());
        $('#hdn_shift1').val($('#spn_Shift').text());
        $('#hdn_date1').val($('#txt_date').val());
        $('#hdn_mach1').val($('#ddl_adminmach').val());
            var dt= $('#hdn_date').val();
            var user=$('#spn_opt').text();
            var shift=$('#spn_Shift').text();
            var sno=$('#Textslno'+r+'').val();
            if(sno == "")
            {
                $('#Textslno'+r+'').css( "background-color","pink" );
                alert('ENTER VALUE');
                $('#Textslno'+r+'').focus();
                return;
            }
            //var sno=$('#Textslno1').val();
            //var code=$('#Textheatcode').val();
            var pidno=$('#spn_pidno'+r+'').val();
            var code=$('#Textheatcode'+r+'').val();
            var textvalues='';//dt+","+shift+","+user;
            var row= $('#hdn_arrylength').val();
            var  marph=parseInt(5)+parseInt(marphs*2);
            var total=marph+parseInt(tott);
            var avg="";
            var tot=0;
            
            var d=1;
            var _cellval=0;
            var _m=1;
            for (var k=6;k<=total+1;k++)
            {
                _cellval+=3;
                var _instcount=minmax[_cellval];
                if(_instcount!="" && _instcount!="0" && _instcount!=null)
                {
                    var _max=minmax[_m];
                    _m+=1;
                    var _min=minmax[_m];
                     _m+=2;
                     d+=1;
                     for(var m=0;m<_instcount;m++)
                     {
                        var val=k+m;
                        if($('#txt_value_'+val+''+r+'').is(':disabled'))
                        {   
                            textvalues+=",None";
                        }
                        else
                        {
                            var txt=$('#txt_value_'+val+''+r+'').val();
                            if(txt=="")
                            {
                                $('#txt_value_'+val+''+r+'').css( "background-color","pink" );
                                alert('ENTER VALUE');
                                $('#txt_value_'+val+''+r+'').focus();
                                return;
                            }
                            
                            
                            else
                            {
                                $('#txt_value_'+val+''+r+'').css( "background-color","#fff" );
                                textvalues+=","+txt;
                                tot=tot+parseFloat(txt);
                            }
                        }
                     }
                    var tot1=tot/2;
                    tot=0;
                    avg+=","+tot1;
                    k+=1;
                   
                }
                else
                {
                    if($('#txt_value_'+k+''+r+'').is(':disabled'))
                    {   
                        textvalues+=",None";
                    }
                    else
                    {
                        var txt=$('#txt_value_'+k+''+r+'').val();
                        if(txt=="")
                        {
                            $('#txt_value_'+k+''+r+'').css( "background-color","pink" );
                            alert('ENTER VALUE');
                            $('#txt_value_'+k+''+r+'').focus();
                            return;
                        }
                        else
                        {
                            $('#txt_value_'+k+''+r+'').css( "background-color","#fff" );
                            textvalues+=","+txt;
                        }
                    }
                    _m+=3;
                }
            }
//            for(var j=6;j<=marph;j++)
//            {
//                if($('#txt_value_'+j+''+r+'').is(':disabled'))
//                {   
//                    textvalues+=",None";
//                }
//                else
//                {
//                    var txt=$('#txt_value_'+j+''+r+'').val();
//                    if(txt=="")
//                    {
//                        $('#txt_value_'+j+''+r+'').css( "background-color","pink" );
//                        alert('ENTER VALUE');
//                        $('#txt_value_'+j+''+r+'').focus();
//                        return;
//                    }
//                    else
//                    {
//                        $('#txt_value_'+j+''+r+'').css( "background-color","#fff" );
//                        textvalues+=","+txt;
//                        tot=parseFloat(tot)+parseFloat(txt);
//                    }
//                    if((j%2)==1)
//                    {
//                        var tot1=parseFloat(tot)/parseFloat(2);
//                        tot=0;
//                        avg+=","+tot1;
//                    }
//                }
//                
//            }
//            for(var z=j;z<=total+1;z++)
//            {
//                if($('#txt_value_'+z+''+r+'').is(':disabled'))
//                {   
//                    textvalues+=",None";
//                }
//                else
//                {
//                    var txt=$('#txt_value_'+z+''+r+'').val();
//                    if(txt=="")
//                    {
//                        $('#txt_value_'+z+''+r+'').css( "background-color","pink" );
//                        alert('ENTER VALUE');
//                        $('#txt_value_'+z+''+r+'').focus();
//                        return;
//                    }
//                    else
//                    {
//                        $('#txt_value_'+z+''+r+'').css( "background-color","#fff" );
//                        textvalues+=","+txt;
//                    }
//                }
//            }
            var part=$('#hdn_partno1').val();
            var operation=$('#hdn_operation').val();
            var unit=$('#hdn_unit').val();
            var cell=$('#hdn_cell').val();
            $.ajax({
                    url:"../Master/Default.aspx/TxtbxadminUpdatevalues",
                    data:"{'Pidno':'"+pidno+"','Sno':'"+sno+"','Code':'"+code+"','Texboxvalues':'"+textvalues+"','Average1':'"+avg+"','ID':'"+id+"','Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
                    type:"POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg)
                    {
                           if(msg.d=="S")
                           {
                             excel=1;
                             getsrhotqty();
                             getsearchmax();
                             //exportoexcel();
                           }
                    },
                    error:function()
                    {}
    });
    },
    error:function()
    {}
  });

}
function getsrhotqty()
{
        var d=$('#txt_date').val();
        var part=$('#hdn_partno1').val();
        var operation=$('#hdn_operation').val();
        var unit=$('#hdn_unit').val();
        var cell=$('#hdn_cell').val();
        $.ajax({
        url:"../Master/Default.aspx/getadminsrchrowcount",
        data:"{'Partno':'"+part+"','Operation':'"+operation+"','Unit':'"+unit+"','Cell':'"+cell+"','Date':'"+d+"','Shift':'"+$('#ddl_adminshift').val()+"','Machine':'"+$('#ddl_adminmach').val()+"','Operator':'"+$('#ddl_adminoperator').val()+"'}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(data)
        {
            if(data!=null && data!="")
            {
                for(var i=0;i<data.d.length;i++)
                {
                    if(data.d[i].Accept=="F")
                    {
                        var url="../Home.aspx";
                        window.top.location.href=url;
                    }
                    else
                    {
                         $('#spn_tot_qty').text(data.d[i].Accept);
                         $('#spn_rej_qty').text(data.d[i].Reject);
                         $('#spn_acc_qty').text(data.d[i]._Accept);
                    }
                }
            }
         },
             error:function()
        {}
      });
}
function exportoexcel()
{
        var html = '';
//        html += $("#div_livedata").html();
        html += $("#div_livedata").html();
        html = $.trim(html);
        html = html.replace(/>/g, '&gt;');
        html = html.replace(/</g, '&lt;');
        $('#hdn_excel').val(html);
        //alert(document.getElementById("div_livedata"));
        document.getElementById("btn_adminexcel").click();
        return false;
}