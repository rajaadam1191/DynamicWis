var rmax=[];
var rmin=[];
var ymean=[];
var other=[];
var minother=[];
var meanother=[];
var ucl=[];
var lcl=[];
var Pmean=[];
var runchart=[];
var f=[];
var excel=0;
f="s";
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
//                    $("select[id$='ddl_partnosrch']").get(0).options.length = 0;
//                    $("select[id$='ddl_partnosrch']").get(0).options[0] = new Option("--- Select Part Number ---", "0");
                    
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
                            //$("select[id$='ddl_partnosrch']").get(0).options[$("select[id$='ddl_partnosrch']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                        
                    }
                    var p=$("input[id$='hdn_part']").val();
                    if(p!="")
                    {
                        $("select[id$='dy_partno']").val(p);
                    }
                    
                    var srchp=$("input[id$='hdn_srchpart']").val();
                    if(srchp!="")
                    {
                        $("select[id$='ddl_partnosrch']").val(srchp);
                    }
                    part=null;
                    comma=null;
                    GetProcess();
              },
                error:function()
                {}
              });
}


function GetProcess()
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
            $("select[id$='dy_operation']").get(0).options.length = 0;
            $("select[id$='dy_operation']").get(0).options[0] = new Option("--- Select Operation ---", "0");
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
                        $("select[id$='dy_operation']").get(0).options[$("select[id$='dy_operation']").get(0).options.length] = new Option(comma[count], "1");                            
                    }
                    else if(comma[count]=="OP2")
                    {
                        $("select[id$='dy_operation']").get(0).options[$("select[id$='dy_operation']").get(0).options.length] = new Option(comma[count], "2");
                    }
                    else
                    {
                        $("select[id$='dy_operation']").get(0).options[$("select[id$='dy_operation']").get(0).options.length] = new Option(comma[count], comma[count]);
                    }
                }
            }
            var p=$("input[id$='hdn_oper']").val();
            if(p!="")
            {
                $("select[id$='dy_operation']").val(p);
            }
            part=null;
            comma=null;
            getCell();
          },
            error:function()
            {}
    });
              
}

function getCell()
{
$.ajax({
        url:"../Master/Default.aspx/getdepartment",
        data:"{'unit':'MBU'}",
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
            var p=$("input[id$='hdncell']").val();
            if(p!="")
            {
                $("select[id$='dy_cell']").val(p);
            }
            
            part=null;
            comma=null;
            getFrequency();
      },
        error:function()
        {}
      });
}

function getFrequency()
{

$.ajax({
        url:"../Master/Default.aspx/getfrequency",
        data:"{}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
       
            $("select[id$='dy_ranges']").get(0).options.length = 0;
            $("select[id$='dy_ranges']").get(0).options[0] = new Option("--- Select Frequency ---", "0");
            part=msg.d;
            comma=part.split(",");
            for(var count=0;count<comma.length;count++)
            {
                if(comma[count]=="")
                {
                }
                else
                {
                    $("select[id$='dy_ranges']").get(0).options[$("select[id$='dy_ranges']").get(0).options.length] = new Option(comma[count], comma[count]);
                }
            }
            var p=$("input[id$='hdn_ranges']").val();
            if(p!="")
            {
                $("select[id$='dy_ranges']").val(p);
            }
            
            part=null;
            comma=null;
            
      },
        error:function()
        {}
      });
}

function getCell1()
{
$.ajax({
        url:"../Master/Default.aspx/getdepartment",
        data:"{'unit':'MBU'}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            $("select[id$='dy_cell1']").get(0).options.length = 0;
            $("select[id$='dy_cell1']").get(0).options[0] = new Option("--- Select Cell ---", "0");
            part=msg.d;
            comma=part.split(",");
            for(var count=0;count<comma.length;count++)
            {
                if(comma[count]=="")
                {
                }
                else
                {
                    $("select[id$='dy_cell1']").get(0).options[$("select[id$='dy_cell1']").get(0).options.length] = new Option(comma[count], comma[count]);
                }
            }
            part=null;
            comma=null;
      },
        error:function()
        {}
      });
}

function getprocess1()
{
        $.ajax({
                url:"../Master/Default.aspx/Get_prtprocess",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    $("select[id$='dy_operation1']").get(0).options.length = 0;
                    $("select[id$='dy_operation1']").get(0).options[0] = new Option("--- Select Operation ---", "0");
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
                                $("select[id$='dy_operation1']").get(0).options[$("select[id$='dy_operation1']").get(0).options.length] = new Option(comma[count], "1");                            
                            }
                            else if(comma[count]=="OP2")
                            {
                                $("select[id$='dy_operation1']").get(0).options[$("select[id$='dy_operation1']").get(0).options.length] = new Option(comma[count], "2");
                            }
                            else
                            {
                                $("select[id$='dy_operation1']").get(0).options[$("select[id$='dy_operation1']").get(0).options.length] = new Option(comma[count], comma[count]);
                            }
                        }
                    }
                  getCell1();
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
                    getprocess1();
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
    if(!noofcell())return false
    if(!range())return false
    if(!RunChart())return false
    var value=$("select[id$='slt_runchart']").val();
    if(value == "Yes")
    {
        if(!runpercent())return false
    }
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
 function srchpartno()
 {
    var part= $("select[id$='ddl_partnosrch']").val();
    if(part=="0")
    { 
       alert('Select Part No');
        return false;
    }
    else
    {
        $("input[id$='hdn_srchpart']").val(part);
       
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
        $("input[id$='hdn_oper']").val(opr);
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
    if(inst=="" || inst==null )
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
 function noofcell()
 {
    var noofcell=$("select[id$='txt_noofcells']").val();
    if(noofcell=="" || noofcell==null || noofcell == "--- Select No Of Cells----")
    {
        alert('Select No of cell');
        return false;
    }
    else
    {
        $("input[id$='hdn_noofcell']").val(noofcell);
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
        $("input[id$='hdn_ranges']").val(range);
        return true;
    }
    
 }
 
 function RunChart()
 {
    var runc=$("select[id$='slt_runchart']").val();
    if(runc=="0")
    {
        alert('Enter Run Chart');
        return false;
    }
    else
    {
        $("input[id$='hdn_runchart']").val(range);
        return true;
    }
    
 }
// function runchart()
// {
//    var run=$("select[id$='hdn_runchart']").val();
//    if(run=="0")
//    {
//        alert('Select Run Chart');
//        return false;
//    }
//    else
//    {
//        $("input[id$='hdn_runchart']").val(run);
//        return true;
//    }
//    
// }
 function runpercent()
 {
    var runper= $("input[id$='txt_RCpercent']").val();
    if(runper=="0" || runper=="")
    { 
        alert('Enter Percentage');
        return false;
    }
    else
    {
        $("input[id$='hdn_runpercent']").val(runper);
       
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
        
        var runchart=$("select[id$='slt_runchart']").val();
//        var checked_radio = $("[id*=RunChart] input:checked");
//        var value = checked_radio.val();
//        var ucl=$("input[id$='txt_ucl']").val();
//        var lcl=$("input[id$='txt_ucl']").val();
        $.ajax({
        
                url:"../Master/Default.aspx/updatedynmaster",
                data:"{'ID':'"+id+"','Part':'"+part+"','Opertaion':'"+oper+"','Unit':'"+unit+"','Cell':'"+cell+"','Instru':'"+instr+"','InstV':'"+instr_v+"','InstR':'"+instr_r+"','Short':'"+short1+"','Cells':'"+cells+"','Header':'"+header+"','Runchart':'"+runchart+"','Ucl':'0','Lcl':'0'}",
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
                        $("input[id$='hdn_oper']").val(msg.d[i].operation);
                        $("input[id$='hdncell']").val(msg.d[i].cell);
                        $("input[id$='hdn_ranges']").val(msg.d[i].inst_ranges);
                        $("input[id$='hdn_noofcell']").val(msg.d[i].cellvalues);
                        getpart();
                       // $("select[id$='dy_operation']").val(msg.d[i].operation);
                        $("select[id$='dy_unit']").val(msg.d[i].unit);
                        $("select[id$='dy_cell']").val(msg.d[i].cell);
                        $("input[id$='dy_intrument']").val(msg.d[i].instrument);
                        $("input[id$='hdn_instname']").val(msg.d[i].instrument);
                        $("input[id$='dy_instruvalues']").val(msg.d[i].inst_values);
                        $("input[id$='hdn_instvalues']").val(msg.d[i].inst_values);
                        $("input[id$='dy_intrument']").attr('disabled',false);
                        $("input[id$='dy_instruvalues']").attr('disabled',false);
                        $("select[id$='dy_ranges']").val(msg.d[i].inst_ranges);
                        $("input[id$='txt_shortname']").val(msg.d[i].shortname);
                        $("input[id$='Txt_headername']").val(msg.d[i].headername);
//                        $("input[id$='txt_noofcells']").val(msg.d[i].cellvalues);
                        if(msg.d[i].cellvalues =="")
                        {
                            $("select[id$='txt_noofcells']").val(0);
                        }
                        else{
                            $("select[id$='txt_noofcells']").val(msg.d[i].cellvalues);
                        }
                        $("select[id$='slt_runchart']").val(msg.d[i].runchart);
                        
                        $.ajax({
                        url:"../Master/Default.aspx/getdynmasterinst",
                        data:"{'id':'"+id+"'}",
                        type:"POST",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(msg)
                        {
                            if(msg.d == "S")
                            {
                                $("input[id$='dy_intrument']").attr('disabled',true);
                                $("input[id$='dy_instruvalues']").attr('disabled',true);
                            }
                        },
                        error:function()
                        {}
                        });  

//                        if(msg.d[i].runchart == "Yes")
//                        {
//                            $("tr[id$='runperccent']").show();
//                            $("input[id$='txt_RCpercent']").val(msg.d[i].runchartpercent);
//                        }
//                        else if(msg.d[i].runchart == "No")
//                        {
//                            $("tr[id$='runperccent']").hide();
//                            $("input[id$='txt_RCpercent']").val(0);
//                        }
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
                            
//                                var srchpartno=$("select[id$='ddl_partnosrch']").val();
//                                $("input[id$='hdn_srchpart']").val(srchpartno);
//                                var url='../Master/DYNMaster.aspx';
//                                window.top.location.href=url;
                               // $.session.set('srchpartno', srchpartno);
//                                getpart();
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
// $(function()
// {
//    $('#btn_view').click(function()
//    {
//        var res=val_values();
//        var _count=0;
//        var _count1=0;
//        if(res==true)
//        {
//             var part=$("select[id$='dy_partno1']").val();
//             var opr=$("select[id$='dy_operation1']").val();
//             var unit=$("select[id$='dy_unit1']").val();
//             var cell=$("select[id$='dy_cell1']").val();
//             $.ajax({
//                    url:"../Master/Default.aspx/getinstruments",
//                    data:"{'Partno':'"+part+"','Opertaion':'"+opr+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
//                    type:"POST",
//                    contentType: "application/json; charset=utf-8",
//                    dataType: "json",
//                    success: function(msg)
//                    {
//                    
//                        part=msg.d;
//                        comma=part.split(",");
//                     
//                      _count=comma.length-1;
//                       var  tbl='<table><TR><TD>';
//                        for(var count=0;count<comma.length;count++)
//                        {
//                        
//                            if(comma[count]=="")
//                            {
//                            }
//                            else
//                            {
//                                    var part1=$("select[id$='dy_partno1']").val();
//                                    var opr1=$("select[id$='dy_operation1']").val();
//                                    var unit1=$("select[id$='dy_unit1']").val();
//                                    var cell1=$("select[id$='dy_cell1']").val();
//                                    var instru=comma[count];
//                                    
//                                    $.ajax({
//                                    url:"../Master/Default.aspx/getinstrumentsvalues",
//                                    data:"{'Instruments':'"+instru+"','Partno':'"+part1+"','Opertaion':'"+opr1+"','Unit':'"+unit1+"','Cell':'"+cell1+"'}",
//                                    type:"POST",
//                                    contentType: "application/json; charset=utf-8",
//                                    dataType: "json",
//                                    success: function(msg)
//                                    {
//                                     
//                                      _count1+=1;
//                                       for(var i=0;i<1;i++)
//                                       {
//                                            var newStr = msg.d[i].Instrument.replace(/\s+/g, '');
//                                            var r_count=0;
//                                            var count=msg.d[i].Count;
//                                            var rcount=msg.d[i].Count1;
//                                            var c_count=parseInt(msg.d[i].Count1)-parseInt(msg.d[i].Count);
//                                            if(parseInt(c_count)>=0)
//                                            {
//                                                tbl+='<table>';
//                                                tbl+='<tr><td><div align="center" style=""><span class="dy_hspan"  id="spn_'+msg.d[i].Instrument+'">'+msg.d[i].Instrument+'</span></div></td></tr>';
//                                                tbl+='<div><table id="tbl_'+msg.d[i].id+'">';
//                                                tbl+='<tr><td><span >S.No</span></td><td></td><td class="dy_td"><span>Dimensions</span></td><td class="dy_td"><span>Upper Specification</span></td><td class="dy_td"><span>Mean Specification</span></td><td class="dy_td"><span>Lower Specification</span></td><td class="dy_td"><span>Frequency</span></td></tr>';
//                                                for(var j=0;j<parseInt(count);j++)
//                                                { 
//                                                    if(msg.d[j].Upper!="")
//                                                   {
//                                                       r_count+=1;
//                                                       tbl+='<tr><td><span>'+r_count+'</span></td><td>:</td><td><input type="text" id="txt_dimension_'+msg.d[i].id+''+j+'" class="dy_text" value='+msg.d[j].Dimession+'></td><td><input type="text" id="txt_max_'+msg.d[i].id+''+j+'" class="dy_text" value='+msg.d[j].Upper+'></td><td><input type="text" id="txt_mean_'+msg.d[i].id+''+j+'"  class="dy_text" value='+msg.d[j].Mean+'></td><td><input type="text" id="txt_min_'+msg.d[i].id+''+j+'"  class="dy_text" value='+msg.d[j].Lower+'></td><td ><input class="dy_text" readonly="readonly" type="text" id="txt_range_'+msg.d[i].id+''+j+'" value='+msg.d[j].Range+' /></td><td style="display:none;"><input class="dy_text" readonly="readonly" type="text" id="txt_id_'+msg.d[i].id+''+j+'" value='+msg.d[j].id1+' /></td></tr>'; 
//                                                   }
//                                                   
//                                                }
//                                                if(c_count>0)
//                                                {
//                                                     for(var k=j;k<parseInt(rcount);k++)
//                                                    { 
//                                                           r_count+=1;
//                                                           tbl+='<tr><td><span>'+r_count+'</span></td><td>:</td><td><input type="text" id="txt_dimension_'+msg.d[i].id+''+k+'" class="dy_text"/></td><td><input type="text" id="txt_max_'+msg.d[i].id+''+k+'" class="dy_text"/></td><td><input type="text" id="txt_mean_'+msg.d[i].id+''+k+'"  class="dy_text"/></td><td><input type="text" id="txt_min_'+msg.d[i].id+''+k+'"  class="dy_text"/></td><td ><input class="dy_text" readonly="readonly" type="text" id="txt_range_'+msg.d[i].id+''+k+'" value='+msg.d[i].Range+' /></td><td style="display:none;"><input class="dy_text" readonly="readonly" type="text" id="txt_id_'+msg.d[i].id+''+k+'" value="0" /></td></tr>'; 
//                                                    }
//                                                }
//                                                tbl+='</table></div></td></tr></table>'; 
//                                            }
//                                            else
//                                            {
//                                                tbl+='<table>';
//                                                tbl+='<tr><td><div align="center" style=""><span class="dy_hspan"  id="spn_'+msg.d[i].Instrument+'">'+msg.d[i].Instrument+'</span></div></td></tr>';
//                                                tbl+='<div><table id="tbl_'+msg.d[i].id+'">';
//                                                tbl+='<tr><td><span >S.No</span></td><td></td><td class="dy_td"><span>Dimensions</span></td><td class="dy_td"><span>Upper Specification</span></td><td class="dy_td"><span>Mean Specification</span></td><td class="dy_td"><span>Lower Specification</span></td><td class="dy_td"><span>Frequency</span></td></tr>';
//                                                for(var j=0;j<parseInt(count);j++)
//                                                { 
//                                                       r_count+=1;
//                                                       tbl+='<tr><td><span>'+r_count+'</span></td><td>:</td><td><input type="text" id="txt_dimension_'+msg.d[i].id+''+j+'" class="dy_text" /></td><td><input type="text" id="txt_max_'+msg.d[i].id+''+j+'" class="dy_text" /></td><td><input type="text" id="txt_mean_'+msg.d[i].id+''+j+'"  class="dy_text" /></td><td><input type="text" id="txt_min_'+msg.d[i].id+''+j+'"  class="dy_text" /></td><td ><input class="dy_text" readonly="readonly" type="text" id="txt_range_'+msg.d[i].id+''+j+'" value='+msg.d[i].Range+' /></td><td style="display:none;"><input class="dy_text" readonly="readonly" type="text" id="txt_id_'+msg.d[i].id+''+j+'" value="0" /></td></tr>'; 
//                                                }
//                                                tbl+='</table></div></td></tr></table>'; 
//                                            }
//                                       }
//                                        
//                                        tbl+='</TD></TR></table>';
//                                        $("div[id$='div_dynvalues']").html(tbl); 
//                                        $("div[id$='div_save']").show(); 
//                                    },
//                                    error:function()
//                                    {}
//                                  });
//                            }
//                            
//                        }
//                    
//                       
//                    },
//                    error:function()
//                    {}
//              });
//        }
//        else
//        {
//        }
//    });
// });

 $(function()
 {
    $('#btn_view').click(function()
    {
        var res=val_values();
        var _count=0;
        var _count1=0;
        if(res==true)
        {
//             var part=$("select[id$='dy_partno1']").val();
//             var opr=$("select[id$='dy_operation1']").val();
//             var unit=$("select[id$='dy_unit1']").val();
//             var cell=$("select[id$='dy_cell1']").val();
//             $.ajax({
//                    url:"../Master/Default.aspx/getinstruments",
//                    data:"{'Partno':'"+part+"','Opertaion':'"+opr+"','Unit':'"+unit+"','Cell':'"+cell+"'}",
//                    type:"POST",
//                    contentType: "application/json; charset=utf-8",
//                    dataType: "json",
//                    success: function(msg)
//                    {
//                    
//                        part=msg.d;
//                        comma=part.split(",");
//                     
//                      _count=comma.length-1;
//                       var  tbl='<table><TR><TD>';
//                        for(var count=0;count<comma.length;count++)
//                        {
//                        
//                            if(comma[count]=="")
//                            {
//                            }
//                            else
//                            {
                                    var  tbl='<table><TR><TD>';
                                    var part1=$("select[id$='dy_partno1']").val();
                                    var opr1=$("select[id$='dy_operation1']").val();
                                    var unit1=$("select[id$='dy_unit1']").val();
                                    var cell1=$("select[id$='dy_cell1']").val();
                                    //var instru=comma[count];
                                    
                                    $.ajax({
                                    url:"../Master/Default.aspx/getinstrumentsvaluesorder",
                                    data:"{'Partno':'"+part1+"','Opertaion':'"+opr1+"','Unit':'"+unit1+"','Cell':'"+cell1+"'}",
                                    type:"POST",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function(msg)
                                    {
                                        var main_count=0;
                                        var prev_dynrefid=0;
                                        var crnt_dynrefid=0;
                                      _count1+=1;
                                       for(var i=0;i<msg.d.length;i++)
                                       {
                                            var newStr = msg.d[i].Instrument.replace(/\s+/g, '');
                                            var r_count=0;
                                            var prev=i-1;
                                            if(parseInt(prev) !='-1')
                                            {
                                                var prev_dynrefid=msg.d[prev].id;
                                            }else
                                            {
                                                var prev_dynrefid=0;
                                            }
                                            var crnt_dynrefid=msg.d[i].id;
                                            var count=msg.d[i].Count;
                                            var rcount=msg.d[i].Count1;
                                            var c_count=parseInt(msg.d[i].Count1)-parseInt(msg.d[i].Count);
                                            var ai=0;
                                            if(parseInt(c_count)>=0)
                                            {
                                                if(parseInt(prev_dynrefid) != parseInt(crnt_dynrefid))
                                                {
                                                    main_count+=1;
                                                    tbl+='<table>';
                                                    tbl+='<tr><td><span class="dy_hspan">'+main_count+'. </span></td><td align="center" colspan="5"><div style=""><span class="dy_hspan"  id="spn_'+msg.d[i].Instrument+'">'+msg.d[i].Instrument+'</span></div></td></tr>';
                                                    tbl+='<div><table id="tbl_'+msg.d[i].id+'">';
                                                    tbl+='<tr><td><span >S.No</span></td><td></td><td class="dy_td"><span>Dimensions</span></td><td class="dy_td"><span>Upper Specification</span></td><td class="dy_td"><span>Mean Specification</span></td><td class="dy_td"><span>Lower Specification</span></td><td class="dy_td"><span>Frequency</span></td><td class="dy_td"><span>Re-order Number</span></td></tr>';
                                                    for(var j=0;j<parseInt(count);j++)
                                                    { 
                                                       var d=i+j;
                                                       if(j==0)
                                                       {
                                                           if(msg.d[j].Upper!="")
                                                           {
                                                               r_count+=1;
                                                               tbl+='<tr><td><span>'+r_count+'</span></td><td>:</td><td><input type="text" id="txt_dimension_'+msg.d[i].id+''+j+'" class="dy_text" value='+msg.d[i].Dimession+'></td><td><input type="text" id="txt_max_'+msg.d[i].id+''+j+'" class="dy_text" onkeypress="return isNumber(event, this);" value="'+msg.d[i].Upper+'"  ></td><td><input type="text" id="txt_mean_'+msg.d[i].id+''+j+'" class="dy_text" onkeypress="return isNumber(event, this);" value="'+msg.d[i].Mean+'"  ></td><td><input type="text" id="txt_min_'+msg.d[i].id+''+j+'"  class="dy_text" onkeypress="return isNumber(event, this);" value="'+msg.d[i].Lower+'" ></td><td ><input class="dy_text" readonly="readonly" type="text" id="txt_range_'+msg.d[i].id+''+j+'" value="'+msg.d[i].Range+'" /></td><td><input type="text" id="txt_reorder_'+msg.d[i].id+''+j+'" value="'+msg.d[i].Reorder+'" class="dy_text" onkeypress="return onlyNumbers_slno(event, this);" /></td><td style="display:none;"><input class="dy_text" readonly="readonly" type="text" id="txt_id_'+msg.d[i].id+''+j+'" value='+msg.d[i].id1+' /></td></tr>'; 
                                                           }
                                                       }
                                                       else
                                                       {
                                                           if(msg.d[j].Upper!="")
                                                           {
                                                               r_count+=1;
                                                               tbl+='<tr><td><span>'+r_count+'</span></td><td>:</td><td><input type="text" id="txt_dimension_'+msg.d[d].id+''+j+'" class="dy_text" value='+msg.d[d].Dimession+'></td><td><input type="text" id="txt_max_'+msg.d[d].id+''+j+'" class="dy_text" onkeypress="return isNumber(event, this);" value="'+msg.d[d].Upper+'"  ></td><td><input type="text" id="txt_mean_'+msg.d[d].id+''+j+'" class="dy_text" onkeypress="return isNumber(event, this);" value="'+msg.d[d].Mean+'"  ></td><td><input type="text" id="txt_min_'+msg.d[d].id+''+j+'"  class="dy_text" onkeypress="return isNumber(event, this);" value="'+msg.d[d].Lower+'"  ></td><td ><input class="dy_text" readonly="readonly" type="text" id="txt_range_'+msg.d[d].id+''+j+'" value="'+msg.d[d].Range+'" /></td><td><input type="text" id="txt_reorder_'+msg.d[d].id+''+j+'" value="'+msg.d[d].Reorder+'" class="dy_text" onkeypress="return onlyNumbers_slno(event, this);" /></td><td style="display:none;"><input class="dy_text" readonly="readonly" type="text" id="txt_id_'+msg.d[d].id+''+j+'" value='+msg.d[d].id1+' /></td></tr>'; 
                                                           }
                                                       }
                                                    }
                                                    if(c_count>0)
                                                    {
                                                        for(var k=j;k<parseInt(rcount);k++)
                                                        { 
                                                           r_count+=1;
                                                           tbl+='<tr><td><span>'+r_count+'</span></td><td>:</td><td><input type="text" id="txt_dimension_'+msg.d[i].id+''+k+'" class="dy_text"/></td><td><input type="text" id="txt_max_'+msg.d[i].id+''+k+'"  onkeypress="return isNumber(event, this);" class="dy_text"/></td><td><input type="text" id="txt_mean_'+msg.d[i].id+''+k+'" onkeypress="return isNumber(event, this);" class="dy_text"/></td><td><input type="text" id="txt_min_'+msg.d[i].id+''+k+'" onkeypress="return isNumber(event, this);"  class="dy_text"/></td><td ><input class="dy_text" readonly="readonly" type="text" id="txt_range_'+msg.d[i].id+''+k+'" value='+msg.d[i].Range+' /></td><td><input type="text" id="txt_reorder_'+msg.d[i].id+''+j+'" value="'+msg.d[i].Reorder+'" class="dy_text" onkeypress="return onlyNumbers_slno(event, this);" /></td><td style="display:none;"><input class="dy_text" readonly="readonly" type="text" id="txt_id_'+msg.d[i].id+''+k+'" value="0" /></td></tr>'; 
                                                        }
                                                    }
                                                    tbl+='</table></div></td></tr></table>'; 
                                                   if(msg.d[i].RUCL!="")
                                                   {
                                                        tbl+='<div><table id="tbl_run'+msg.d[i].id+'">';
                                                        tbl+='<tr><td class="dy_td"><span>Upper Control Limit</span></td><td class="dy_td"><span>Process Mean</span></td><td class="dy_td"><span>Lower Control Limit</span></td></tr>';
                                                        for(var r=0;r<parseInt(count);r++)
                                                        { 
        //                                                   if(msg.d[r].RUCL!="")
        //                                                   {
    //                                                           tbl+='<tr><td><input type="text" id="txt_rucl_'+msg.d[i].id+''+r+'" class="dy_text" value='+msg.d[i].RUCL+'></td><td><input type="text" id="txt_pmean_'+msg.d[i].id+''+r+'" class="dy_text" value='+msg.d[i].RLCL+'></td><td><input type="text" id="txt_rlcl_'+msg.d[i].id+''+r+'"  class="dy_text" value='+msg.d[i].RPmean+'></td></tr>'; 
        //                                                   }
                                                           var d=i+r;
                                                           if(r==0)
                                                           {
                                                               if(msg.d[i].RUCL!="")
                                                               {
                                                                   tbl+='<tr><td><input type="text" id="txt_rucl_'+msg.d[i].id+''+r+'" class="dy_text" onkeypress="return isNumber(event, this);" value="'+msg.d[i].RUCL+'"  ></td><td><input type="text" id="txt_pmean_'+msg.d[i].id+''+r+'" class="dy_text" onkeypress="return isNumber(event, this);" value="'+msg.d[i].RPmean+'"  ></td><td><input type="text" id="txt_rlcl_'+msg.d[i].id+''+r+'"  class="dy_text" onkeypress="return isNumber(event, this);" value="'+msg.d[i].RLCL+'"  ></td></tr>'; 
                                                               }
                                                           }
                                                           else
                                                           {
                                                               if(msg.d[i].RUCL!="")
                                                               {
                                                                    tbl+='<tr><td><input type="text" id="txt_rucl_'+msg.d[d].id+''+r+'" class="dy_text" onkeypress="return isNumber(event, this);" value="'+msg.d[d].RUCL+'"  ></td><td><input type="text" id="txt_pmean_'+msg.d[d].id+''+r+'" class="dy_text" onkeypress="return isNumber(event, this);" value="'+msg.d[d].RPmean+'"  ></td><td><input type="text" id="txt_rlcl_'+msg.d[d].id+''+r+'"  class="dy_text" onkeypress="return isNumber(event, this);" value="'+msg.d[d].RLCL+'"  ></td></tr>'; 
                                                               }
                                                           }
                                                        }
                                                        tbl+='</table></div>';
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                main_count+=1;
                                                tbl+='<table>';
                                                tbl+='<tr><td><span class="dy_hspan">'+main_count+'. </span></td><td colspan="5" align="center"><div style=""><span class="dy_hspan"  id="spn_'+msg.d[i].Instrument+'">'+msg.d[i].Instrument+'</span></div></td></tr>';
                                                tbl+='<div><table id="tbl_'+msg.d[i].id+'">';
                                                tbl+='<tr><td><span >S.No</span></td><td></td><td class="dy_td"><span>Dimensions</span></td><td class="dy_td"><span>Upper Specification</span></td><td class="dy_td"><span>Mean Specification</span></td><td class="dy_td"><span>Lower Specification</span></td><td class="dy_td"><span>Frequency</span></td><td class="dy_td"><span>Re-order Number</span></td></tr>';
                                                for(var j=0;j<parseInt(count);j++)
                                                { 
                                                       r_count+=1;
                                                       tbl+='<tr><td><span>'+r_count+'</span></td><td>:</td><td><input type="text" id="txt_dimension_'+msg.d[i].id+''+j+'" class="dy_text" /></td><td><input type="text" id="txt_max_'+msg.d[i].id+''+j+'" class="dy_text" onkeypress="return isNumber(event, this);"/></td><td><input type="text" id="txt_mean_'+msg.d[i].id+''+j+'"  class="dy_text" onkeypress="return isNumber(event, this);" /></td><td><input type="text" id="txt_min_'+msg.d[i].id+''+j+'" class="dy_text" onkeypress="return isNumber(event, this);" /></td><td ><input class="dy_text" readonly="readonly" type="text" id="txt_range_'+msg.d[i].id+''+j+'" value='+msg.d[i].Range+' /></td><td><input type="text" id="txt_reorder_'+msg.d[i].id+''+j+'" value="'+msg.d[i].Reorder+'" class="dy_text" onkeypress="return onlyNumbers_slno(event, this);" /></td><td style="display:none;"><input class="dy_text" readonly="readonly" type="text" id="txt_id_'+msg.d[i].id+''+j+'" value="0" /></td></tr>'; 
                                                }
                                                tbl+='</table></div></td></tr></table>'; 
                                                if(msg.d[i].RUCL!="")
                                                {
                                                    tbl+='<div><table id="tbl_run'+msg.d[i].id+'">';
                                                    tbl+='<tr><td class="dy_td"><span>Upper Control Limit</span></td><td class="dy_td"><span>Process Mean</span></td><td class="dy_td"><span>Lower Control Limit</span></td></tr>';
                                                    for(var r=0;r<parseInt(count);r++)
                                                    { 
                                                       if(msg.d[i].RUCL!="")
                                                       {
                                                            tbl+='<tr><td><input type="text" id="txt_rucl_'+msg.d[i].id+''+r+'" class="dy_text" onkeypress="return isNumber(event, this);" value="'+msg.d[i].RUCL+'"  ></td><td><input type="text" id="txt_pmean_'+msg.d[i].id+''+r+'" class="dy_text" onkeypress="return isNumber(event, this);" value="'+msg.d[i].RPmean+'"  ></td><td><input type="text" id="txt_rlcl_'+msg.d[i].id+''+r+'"  class="dy_text" onkeypress="return isNumber(event, this);" value="'+msg.d[i].RLCL+'"  ></td></tr>'; 
                                                       }
                                                    }
                                                    tbl+='</table></div>';
                                                }
                                            }
                                       }
                                        
                                        tbl+='</TD></TR></table>';
                                        $("div[id$='div_dynvalues']").html(tbl); 
                                        $("div[id$='div_save']").show(); 
                                    },
                                    error:function()
                                    {}
                                  });
//                            }
//                            
//                        }
//                    
//                       
//                    },
//                    error:function()
//                    {}
//              });
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
//                            var runtable = document.getElementById("tbl_run"+newStr+"");
//                            var runtblength=runtable.rows.length-1;
                            for(var k=0;k<tblength;k++)
                            {
                                if($('#txt_dimension_'+newStr+''+k+'').val() == "")
                                {
                                    $('#txt_dimension_'+newStr+''+k+'').val('-');
                                }
                                if($('#txt_max_'+newStr+''+k+'').val() == "")
                                {
                                    $('#txt_max_'+newStr+''+k+'').val('-');
                                }
                                if($('#txt_mean_'+newStr+''+k+'').val() == "")
                                {
                                    $('#txt_mean_'+newStr+''+k+'').val('-');
                                }
                                if($('#txt_min_'+newStr+''+k+'').val() == "")
                                {
                                    $('#txt_min_'+newStr+''+k+'').val('-');
                                }
                                
                                if($('#txt_rucl_'+newStr+''+k+'').val() == "")
                                {
                                    $('#txt_rucl_'+newStr+''+k+'').val('-');
                                }
                                if($('#txt_pmean_'+newStr+''+k+'').val() == "")
                                {
                                    $('#txt_pmean_'+newStr+''+k+'').val('-');
                                }
                                if($('#txt_rlcl_'+newStr+''+k+'').val() == "")
                                {
                                    $('#txt_rlcl_'+newStr+''+k+'').val('-');
                                }
                                var rucl=$('#txt_rucl_'+newStr+''+k+'').val();
                                var pmean=$('#txt_pmean_'+newStr+''+k+'').val();
                                var rlcl=$('#txt_rlcl_'+newStr+''+k+'').val();

                                flag=parseInt(flag)+1;
                                var instru=comma[count];
                                var dim=$('#txt_dimension_'+newStr+''+k+'').val();
                                var max=$('#txt_max_'+newStr+''+k+'').val();
                                var mean=$('#txt_mean_'+newStr+''+k+'').val();
                                var min=$('#txt_min_'+newStr+''+k+'').val();
                                var ranng=$('#txt_range_'+newStr+''+k+'').val();
                                var id=$('#txt_id_'+newStr+''+k+'').val();
                                var reorder=$('#txt_reorder_'+newStr+''+k+'').val();
                                var part=$("select[id$='dy_partno1']").val();
                                var opr=$("select[id$='dy_operation1']").val();
                                var unit=$("select[id$='dy_unit1']").val();
                                var cell=$("select[id$='dy_cell1']").val();
                                 $.ajax({
                                        url:"../Master/Default.aspx/SaveDYNValues",
                                        data:"{'Partno':'"+part+"','Opertaion':'"+opr+"','Unit':'"+unit+"','Cell':'"+cell+"','Dim':'"+dim+"','Max':'"+max+"','Mean':'"+mean+"','Min':'"+min+"','Range':'"+ranng+"','Instrument':'"+instru+"','ID':'"+id+"','Flag':'"+flag+"','RUCL':'"+rucl+"','RLCL':'"+rlcl+"','RPMean':'"+pmean+"','Reorder':'"+reorder+"'}",
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
                                        $('#btn_view').click();
                                        alert('Saved Successfully');
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
 
 //design partof qualitysheet
function get_designvalue()
{
var newWidth = 0;
var dynwidth=0;
var max='';
var min='';
var mean='';
var ymax='';
var ymin='';
var others='';
var minothers='';
var meanothers='';
var uclvalue='';
var lclvalue='';
var Pmeanvalue='';
var runchartvalue='';
var tot=0;
        $.ajax({
                url:"../Master/Default.aspx/GetQualitydesign",
                data:"{}",
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
                              
                    for (var i = 0; i < data.d.length; i++)
                    {
                        var rowcount= $('#hdn_getrowcount').val();
                        if (rowcount<=10)
                        {
                            if(data.d[i].Cellvalue!="" && data.d[i].Cellvalue!="0" && data.d[i].Cellvalue!=null)
                            {
                                max+=","+data.d[i].UpperSpecification;
                                min+=","+data.d[i].LowerSpecification;
                                mean+=","+data.d[i].Mean;
                                tbl+='<td style="border:none;"><div id=div_'+i+'  style="float: left;" ><table id="Maintable" style=" border-collapse: collapse;">';
                                tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2" class="styleHDR" style="text-align:center;width:196.3px;height:14.5ptpt;color:#FFF;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Frequency + '</span> </td></tr>';
                                tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2" class="styleHDR" style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Dimensions + '</span> </td></tr>';
                                tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2" class="styleHDR" style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].UpperSpecification + '</span> </td></tr>';
                                tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2"  style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].Mean + '</span></td></tr>';
                                tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2"  style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].LowerSpecification + '</span> </td></tr>';
                                tbl+='</table></div></td>';
                                
                                ttbl+='<td style="border:none;"><div id=div_'+i+'  style="float: left;" ><table id="Maintable" style=" border-collapse: collapse;">';
                                ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2" class="styleHDR" style="text-align:center;width:196.3px;height:14.5pt;color:#FFF;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Frequency + '</span> </td></tr>';
                                ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2" class="styleHDR" style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Dimensions + '</span> </td></tr>';
                                ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2" class="styleHDR" style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].UpperSpecification + '</span> </td></tr>';
                                ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2"  style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].Mean + '</span></td></tr>';
                                ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2"  style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].LowerSpecification + '</span> </td></tr>';
                                ttbl+='</table></div></td>';
                            }
                            if(data.d[i].Cellvalue=="" ||data.d[i].Cellvalue =="0" || data.d[i].Cellvalue == null)
                            {
                               others+=","+data.d[i].UpperSpecification;
                               minothers+=","+data.d[i].LowerSpecification;
                               meanothers+=","+data.d[i].Mean;
                               uclvalue+=","+data.d[i].UpperControlLimit;
                               lclvalue+=","+data.d[i].LowerControlLimit;
                               Pmeanvalue+=","+data.d[i].ProcessMean;
                               runchartvalue+=","+data.d[i].RunChart;
                               tbl+='<td style="border:none;"><div id=div_'+i+'  style="float: left;" ><table id="Maintable" style=" border-collapse: collapse;">';
                               tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:195.8px;height:14.5pt;color:#FFF;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Frequency + '</span> </td></tr>';
                               tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:195.8px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Dimensions + '</span> </td></tr>';
                               tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:195.8px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].UpperSpecification + '</span> </td></tr>';
                               tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td style="text-align:center;width:195.8px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].Mean + '</span></td></tr>';
                               tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td style="text-align:center;width:195.8px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].LowerSpecification + '</span> </td></tr>';
                               tbl+='</table></div></td>';
                               
                               ttbl+='<td style="border:none;"><div id=div_'+i+'  style="float: left;" ><table id="Maintable" style=" border-collapse: collapse;">';
                               ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:195.8px;height:14.5pt;color:#FFF;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Frequency + '</span> </td></tr>';
                               ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:195.8px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Dimensions + '</span> </td></tr>';
                               ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:195.8px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].UpperSpecification + '</span> </td></tr>';
                               ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td style="text-align:center;width:195.8px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].Mean + '</span></td></tr>';
                               ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td style="text-align:center;width:195.8px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].LowerSpecification + '</span> </td></tr>';
                               ttbl+='</table></div></td>';
                            }
                         }
                         else
                         {
                            if(data.d[i].Cellvalue!="" && data.d[i].Cellvalue!="0" && data.d[i].Cellvalue!=null)
                            {
                                max+=","+data.d[i].UpperSpecification;
                                min+=","+data.d[i].LowerSpecification;
                                mean+=","+data.d[i].Mean;
                                tbl+='<td style="border:none;"><div id=div_'+i+'  style="float: left;" ><table id="Maintable" style=" border-collapse: collapse;">';
                                tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2" class="styleHDR" style="text-align:center;width:196.3px;height:14.5ptpt;color:#FFF;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Frequency + '</span> </td></tr>';
                                tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2" class="styleHDR" style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Dimensions + '</span> </td></tr>';
                                tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2" class="styleHDR" style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].UpperSpecification + '</span> </td></tr>';
                                tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2"  style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].Mean + '</span></td></tr>';
                                tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2"  style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].LowerSpecification + '</span> </td></tr>';
                                tbl+='</table></div></td>';
                                
                                ttbl+='<td style="border:none;"><div id=div_'+i+'  style="float: left;" ><table id="Maintable" style=" border-collapse: collapse;">';
                                ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2" class="styleHDR" style="text-align:center;width:196.3px;height:14.5pt;color:#FFF;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Frequency + '</span> </td></tr>';
                                ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2" class="styleHDR" style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Dimensions + '</span> </td></tr>';
                                ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2" class="styleHDR" style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].UpperSpecification + '</span> </td></tr>';
                                ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2"  style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].Mean + '</span></td></tr>';
                                ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td colspan="2"  style="text-align:center;width:196.3px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].LowerSpecification + '</span> </td></tr>';
                                ttbl+='</table></div></td>';
                            }
                            if(data.d[i].Cellvalue=="" ||data.d[i].Cellvalue =="0" || data.d[i].Cellvalue == null)
                            {
                               others+=","+data.d[i].UpperSpecification;
                               minothers+=","+data.d[i].LowerSpecification;
                               meanothers+=","+data.d[i].Mean;
                               uclvalue+=","+data.d[i].UpperControlLimit;
                               lclvalue+=","+data.d[i].LowerControlLimit;
                               Pmeanvalue+=","+data.d[i].ProcessMean;
                               runchartvalue+=","+data.d[i].RunChart;
                               tbl+='<td style="border:none;"><div id=div_'+i+'  style="float: left;" ><table id="Maintable" style=" border-collapse: collapse;">';
                               tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:195.2px;height:14.5pt;color:#FFF;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Frequency + '</span> </td></tr>';
                               tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:195.2px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Dimensions + '</span> </td></tr>';
                               tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:195.2px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].UpperSpecification + '</span> </td></tr>';
                               tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td style="text-align:center;width:195.2px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].Mean + '</span></td></tr>';
                               tbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td style="text-align:center;width:195.2px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].LowerSpecification + '</span> </td></tr>';
                               tbl+='</table></div></td>';
                               
                               ttbl+='<td style="border:none;"><div id=div_'+i+'  style="float: left;" ><table id="Maintable" style=" border-collapse: collapse;">';
                               ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:195.2px;height:14.5pt;color:#FFF;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Frequency + '</span> </td></tr>';
                               ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:195.2px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].Dimensions + '</span> </td></tr>';
                               ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="styleHDR" style="text-align:center;width:195.2px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;"> <span>' + data.d[i].UpperSpecification + '</span> </td></tr>';
                               ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td style="text-align:center;width:195.2px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].Mean + '</span></td></tr>';
                               ttbl+='<tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td style="text-align:center;width:195.2px;height:15pt;color:#fff;border-bottom:solid 1.4px #fff;" class="styleHDR"> <span>' + data.d[i].LowerSpecification + '</span> </td></tr>';
                               ttbl+='</table></div></td>';
                            }
                         }
                    }
                    
                     tbl+='</tr></table></div>';
                     ttbl+='</tr></table></td>';
                     ttbl+='</tr></table></div>';
                     $('#div_dyn').html(tbl);
                     $('#div_qualitysheet').html(ttbl);
                     $('#hdn_max').val(max);
                     $('#hdn_min').val(min);
                     rmax=max.split(",");
                     rmin=min.split(",");
                     ymean=mean.split(",");
                     other=others.split(",");
                     minother=minothers.split(",");
                     meanother=meanothers.split(",");
                     ucl=uclvalue.split(",");
                     lcl=lclvalue.split(",");
                     Pmean=Pmeanvalue.split(",");
                     runchart=runchartvalue.split(",");
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
                      dynwidth=newWidth+parseInt(190)+parseInt(95);
                      $("#div_width_dyn").width(dynwidth)
                      $("#div_headerlabel").width(dynwidth);
                      $("#div_qsheet").width(dynwidth);
                      $("#div_lbl").width(dynwidth);
                      $("#div_tab").width(dynwidth); 
                      $("#wrap").width(dynwidth+613);                      
                      var totalwidth=(dynwidth+613)/5;
                      totalwidth=totalwidth-0.5;
//                      $("#link_production").width(totalwidth);       
//                      $("#linkproductiondata").width(totalwidth);       
//                      $("#link_downtime").width(totalwidth);
//                      $("#link_Chart").width(totalwidth);       
//                      $("#link_logout").width(totalwidth);       
                      $("#link_production").width(225);       
                      $("#linkproductiondata").width(225);       
                      $("#link_downtime").width(225);
                      $("#link_Chart").width(225);       
                      $("#link_logout").width(225);       
                },
                error:function()
                {}
              });
}
function getmaxmin()
{

    var max='';
    var min='';
 
    $.ajax({
                url:"../Master/Default.aspx/Get_maxmin",
                data:"{}",
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
var count1=0;
    var minmax=[];
    minmax=MaxMin;
   
        var tot=$('#hdn_instcount').val();
        $.ajax({
                url:"../Master/Default.aspx/ReadExistinValues",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg!=null && msg!="")
                    {
                        var edit=1;
                        var cmt=1;
                        var time=1;
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
//                        marphs=parseInt(5)+parseInt(marphs);
//                        var total=parseInt(marphs)+parseInt(tot);
                        cmt=cmt+parseInt(total);
                        time=time+cmt;
                        edit=edit+time;
                        var rowid=1;
                        var tbl="<div id='div_datascroll' style='margin-left:-487px;'><table id='tb_label'  style='border: 0px solid black;border-collapse: collapse;background-color:#eefaff;'>";
                        var _tbl="<div style=''><table id='tb_label' width='' style='border: 0px solid black;border-collapse: collapse;background-color:#eefaff;'>";
                        for(var i=0;i<msg.d.length;i++)
                        {
                                var _cellval=0;
                                var _cellval1=0;
                                var _m=1;
                                var _m1=1;
                                var reject='';
                                $('#hdn_arrylength').val(msg.d[i].arr_val.length);
                                tbl+="<tr style=''><td style='border:none;'><div style='border:none;margin-top:-2px;display:block;'id='div_edit_"+i+"'><table style='border:none;border-collapse: collapse;'><tr style='border:none;height:30px;'><td style='text-align:center;height:10pt;width:95px;' class='styleHDR'><span id='spn_date'>"+msg.d[i].arr_val[0]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:93px;' class='styleHDR'><span id='spn_pidno'>"+msg.d[i].arr_val[1]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:47px;' class='styleHDR'><span id='spn_Shift'>"+msg.d[i].arr_val[2]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:98px;' class='styleHDR'><span id='spn_opt'>"+msg.d[i].arr_val[3]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:50px;'  class='styleHDR'><span>"+msg.d[i].arr_val[4]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:104.5px;'  class='styleHDR'><span>"+msg.d[i].arr_val[5]+"</span></td>";
                                _tbl+="<tr><td style='border:none;'><div style='border:none;margin-top:-2px;display:block;'id='div_edit_"+i+"'><table style='border:none;border-collapse: collapse;'><tr style='border:none;'><td style='text-align:center;height:10pt;width:98px;' class='styleHDR'><span id='spn_date'>"+msg.d[i].arr_val[0]+"</span></td>";
                                _tbl+="<td style='text-align:center;height:10pt;width:93px;' class='styleHDR'><span id='spn_pidno'>"+msg.d[i].arr_val[1]+"</span></td>";
                                _tbl+="<td style='text-align:center;height:10pt;width:47px;' class='styleHDR'><span id='spn_Shift'>"+msg.d[i].arr_val[2]+"</span></td>";
                                _tbl+="<td style='text-align:center;height:10pt;width:98px;' class='styleHDR'><span id='spn_opt'>"+msg.d[i].arr_val[3]+"</span></td>";
                                _tbl+="<td style='text-align:center;height:10pt;width:50px;' class='styleHDR'><span>"+msg.d[i].arr_val[4]+"</span></td>";
                                _tbl+="<td style='text-align:center;height:10pt;width:98px;' class='styleHDR'><span>"+msg.d[i].arr_val[5]+"</span></td>";
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
                                            else if(msg.d[i].arr_val[k+m] =="-")
                                            {
                                                sty='background-color:orange;'
                                            }
                                            else
                                            {
                                                sty="background-color:green";
                                            }
                                             tbl+='<td style="text-align:center;width:100px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k+m]+ '</td>';
                                             _tbl+='<td style="text-align:center;width:101.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k+m]+ '</td>';
                                         }
                                         
                                         k+=1;
//                                         if(k%2==1)
//                                         {
//                                             _m+=1;
//                                         }
//                                         else
//                                         {
//                                             _m+=-1;
//                                         }
                                       
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
                                            tbl+='<td style="text-align:center;width:202px;'+sty+'" class="styleHDR"></td>';
                                            _tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k]+ '</td>';
                                        }
                                        else
                                        {
                                            tbl+='<td style="text-align:center;width:202px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k]+ '</td>';
                                            _tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[k]+ '</td>';
                                        }
                                        _m+=3;
                                    }
                                    
                                        
                                }
//                                for (var l=k;l<=total;l++)
//                                {
//                                
//                                     var _max=minmax[_m];
//                                     var _min=minmax[_m + 1];
//                                     var values1=parseFloat(msg.d[i].arr_val[l]);
//                                     var vis_val=msg.d[i].arr_val[l];
//                                     if(values1 > parseFloat(_max) || values1 < parseFloat(_min)|| vis_val == "not ok"|| vis_val =="notok" || vis_val =="NOT OK" || vis_val =="NOTOK")
//                                     {
//                                        var sty='background-color:red;'
//                                     }
//                                   else if(vis_val =="-")
//                                   {
//                                   var sty='background-color:orange;'
//                                   }
//                                     else
//                                     {
//                                         var sty='background-color:none;'
//                                     }
//                                     if(msg.d[i].arr_val[l]=="None")
//                                     {
//                                        tbl+='<td style="text-align:center;width:202px;'+sty+'" class="styleHDR"></td>';
//                                         _tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[l]+ '</td>';
//                                     }
//                                     else
//                                     {
//                                        tbl+='<td style="text-align:center;width:202px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[l]+ '</td>';
//                                         _tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR">' + msg.d[i].arr_val[l]+ '</td>';
//                                     }
//                                    
//                                   
//                                   _m+=2;
//                                }
                                for (var a=k;a<=cmt;a++)
                                {
                                  tbl+='<td style="text-align:center;width:97px;" class="styleHDR">' + msg.d[i].arr_val[a]+ '</td>';
                                  _tbl+='<td style="text-align:center;width:100px;" class="styleHDR">' + msg.d[i].arr_val[a]+ '</td>';
                                }
                                for (var n=a;n<=time;n++)
                                {
                                  tbl+='<td style="text-align:center;width:97px;" class="styleHDR">' + msg.d[i].arr_val[n]+ '</td>';
                                  _tbl+='<td style="text-align:center;width:100px;" class="styleHDR">' + msg.d[i].arr_val[n]+ '</td>';
                                }
                                for (var x=n;x<=edit;x++)
                                {
                                  tbl+='<td style="border: 1px solid black;width:92px;"><input type="image" src="../images/Editnew.jpg"  id="divedit_'+i+'" alt="Edit"   style="width:25px;margin-left:35px;" onclick="javascript:show1('+i+');"/></td>';
                                }
                                tbl+="</tr></table></div>";
                                _tbl+="</tr></table></div>";
                                tbl+="<div style='border:none;margin-top:-2px;display:none;'id='div_update_"+i+"'><table style='border:none;border-collapse: collapse;background-color:#fff;'><tr style='border:none;height:30px;'><td style='text-align:center;height:10pt;width:95px;' class='styleHDR'><span id='spn_date'>"+msg.d[i].arr_val[0]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:93px;' class='styleHDR'><span id='spn_pidno'>"+msg.d[i].arr_val[1]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:47px;' class='styleHDR'><span id='spn_Shift'>"+msg.d[i].arr_val[2]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:98px;' class='styleHDR'><span id='spn_opt'>"+msg.d[i].arr_val[3]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:50px;' class='styleHDR'><span>"+msg.d[i].arr_val[4]+"</span></td>";
                                tbl+="<td style='text-align:center;height:10pt;width:104.5px;' class='styleHDR'><span>"+msg.d[i].arr_val[5]+"</span></td>";
                                var d1=1;
                                var count;
                                
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
                                                count=parseInt(d1)-parseInt(1);
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
                                                else if(msg.d[i].arr_val[val] =="-")
                                                {
                                                     sty='background-color:orange;'
                                                }
                                                else
                                                {
                                                    sty="background-color:green";
                                                }
                                                  tbl+='<td style="text-align:center;width:99.3px;'+sty+'" class="styleHDR"><input type="text" id="txt_value_'+val+''+i+'"  style="width:95px;height: 15pt;border:none;text-align:center;'+sty+'" class="MrpTxtBox_dyn" value=' + msg.d[i].arr_val[val]+ ' onblur="javascript:checkuprange('+val+','+i+','+count+');"></td>';
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
//                                        var count1=0;
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
                                                   //tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR"><input type="text"  id="txt_value_'+l+''+i+'" style="width:195px;height: 20pt;border:none;text-align:center;'+sty+'" class="RghTxtBox_dyn" value="" disabled="disabled"></td>';
                                                     tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR"><input type="text"  id="txt_value_'+k+''+i+'" style="width:195px;height: 20pt;border:none;text-align:center;'+sty+'" class="RghTxtBox_dyn" value="" "></td>';
                                                 }
                                                 else{
                                                   tbl+='<td style="text-align:center;width:200px;'+sty+'" class="styleHDR"><input type="text"  id="txt_value_'+k+''+i+'" style="width:155px;height: 20pt;border:none;text-align:center;'+sty+'" class="RghTxtBox_dyn" value=' + msg.d[i].arr_val[k]+ ' onkeypress="return isNumber_QS(event, this);" onblur="javascript:changeothertab1('+count1+','+k+','+i+');"></td>';
                                                   }
                                                 _m1+=3;
                                            }
                                            else
                                            {
                                                tbl+='<td style="text-align:center;width:101.3px" class="styleHDR"><input type="text"  id="txt_value_'+k+''+i+'" style="width:50px;height: 15pt;border:none;text-align:center;" class="RghTxtBox_dyn" value="" "></td>';
                                                //tbl+='<td style="text-align:center;width:101.3px" class="styleHDR"><input type="text"  id="txt_value_'+l+''+i+'" style="width:50px;height: 15pt;border:none;text-align:center;" class="RghTxtBox_dyn" value="" disabled="disabled"></td>';
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
//                                            count=parseInt(d1)-parseInt(1);
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
//                                 var count1=0;
//                                for (var l=k;l<=total;l++)
//                                {
//                                    if(msg.d[i].arr_val[l]!=null && msg.d[i].arr_val[l]!="")
//                                    {
//                                    
//                                        count1+=1;
//                                         var _max=minmax[_m1];
//                                          var _min=minmax[_m1 + 1];
//                                         var values1=parseFloat(msg.d[i].arr_val[l]);
//                                         var vis_val=msg.d[i].arr_val[l];
//                                         if(values1 > parseFloat(_max) || values1 < parseFloat(_min) || vis_val == "not ok"|| vis_val =="notok" || vis_val =="NOT OK" || vis_val =="NOTOK")
//                                         {
//                                            var sty='background-color:red;'
//                                            reject='1';
//                                         }
//                                         else if(vis_val =="-")
//                                         {
//                                           var sty='background-color:orange;'
//                                         }
//                                         else
//                                         {
//                                             var sty='background-color:none;'
//                                         }
//                                         if(msg.d[i].arr_val[l]=="None")
//                                         {
//                                           // tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR"><input type="text"  id="txt_value_'+l+''+i+'" style="width:195px;height: 20pt;border:none;text-align:center;'+sty+'" class="RghTxtBox_dyn" value="" disabled="disabled"></td>';
//                                                               tbl+='<td style="text-align:center;width:203.5px;'+sty+'" class="styleHDR"><input type="text"  id="txt_value_'+l+''+i+'" style="width:195px;height: 20pt;border:none;text-align:center;'+sty+'" class="RghTxtBox_dyn" value="" "></td>';
//                                         }
//                                         else{
//                                           tbl+='<td style="text-align:center;width:200px;'+sty+'" class="styleHDR"><input type="text"  id="txt_value_'+l+''+i+'" style="width:155px;height: 20pt;border:none;text-align:center;'+sty+'" class="RghTxtBox_dyn" value=' + msg.d[i].arr_val[l]+ ' onblur="javascript:changeothertab1('+count1+','+l+','+i+');"></td>';
//                                           }
//                                           _m1+=2;
//                                    }
//                                    else
//                                    {
//                                        tbl+='<td style="text-align:center;width:101.3px" class="styleHDR"><input type="text"  id="txt_value_'+l+''+i+'" style="width:50px;height: 15pt;border:none;text-align:center;" class="RghTxtBox_dyn" value="" "></td>';
//                                  //    tbl+='<td style="text-align:center;width:101.3px" class="styleHDR"><input type="text"  id="txt_value_'+l+''+i+'" style="width:50px;height: 15pt;border:none;text-align:center;" class="RghTxtBox_dyn" value="" disabled="disabled"></td>';
//                                    }
//                                     
//                                }
                                for (var a=k;a<=cmt;a++)
                                {
                                  tbl+='<td style="text-align:center;width:97px;" class="styleHDR"><input type="text" id="txt_value_'+a+''+i+'" style="width:25px;height: 15pt;border:none;text-align:center;" class="TxtBox_dyn9" value=' + msg.d[i].arr_val[a]+ '></td>';
                                }
                                for (var n=a;n<=time;n++)
                                {
                                  tbl+='<td style="text-align:center;width:97px;" class="styleHDR"><span id="span_value_'+a+''+i+'" style="width:25px;height: 15pt;border:none;text-align:center;" class="TxtBox_dyn9" >' + msg.d[i].arr_val[n]+ '</span></td>';
                                }
                                for (var x=n;x<=edit;x++)
                                {
                                    var id=msg.d[i].arr_val[x];
                             
                                    //tbl+='<td style="border: 1px solid black;width:99px;"><div align="center" style="margin-left:20px;" id="update_'+i+'"><table><tr><td style="width:50px;"><input type="image" src="../images/update.jpg"   alt="Edit" class="inputClass"  style="width:25px;" onclick="javascript:update('+msg.d[i].arr_val[x]+','+i+','+marphs1+','+tot+','+msg.d[i].arr_val[1]+');"/></td><td style="width:50px;"><input type="image" src="../images/Delete.png"   alt="Edit" class="inputClass"  style="width:25px;" onclick="javascript:Cancel('+i+');"/></td></tr></table></div></td>';
                                    tbl+='<td style="border: 1px solid black;width:92px;"><div align="center" style="margin-left:20px;" id="update_'+i+'"><table><tr><td style="width:50px;"><input type="image" src="../images/update.jpg"   alt="Edit" class="inputClass"  style="width:25px;" onclick="javascript:update('+msg.d[i].arr_val[x]+','+i+','+marphs1+','+tot+');"/></td><td style="width:50px;"><input type="image" src="../images/Delete.png"   alt="Edit" class="inputClass"  style="width:25px;" onclick="javascript:Cancel('+i+');"/></td></tr></table></div></td>';
                              
                                     $.ajax({
                                            url:"../Master/Default.aspx/UpdateRejectValues",
                                            data:"{'ID':'"+id+"','Reject':'"+reject+"'}",
                                            type:"POST",
                                            contentType: "application/json; charset=utf-8",
                                            dataType: "json",
                                            success: function(msg)
                                            {
                                                if(msg.d=="S")
                                                {
                                                   
                                                }
                                            },
                                            error: function (xhr, ajaxOptions, thrownError) {
                                            alert(xhr.status);
                                            alert(thrownError);
                                            var err = eval("(" + xhr.responseText + ")");
                                            alert(err.Message);
                                            }
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
                                showtxbx();  
                                getotqty(); 
                                if(excel== 1)
                                {
                                    exportoexcel(); 
                                }
                    }
                    else
                    {
                        showtxbx();
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
                var err = eval("(" + xhr.responseText + ")");
                alert(err.Message);
                }
              });
}
function getinstcount()
{
 
    $.ajax({
        url:"../Master/Default.aspx/getcount",
        data:"{}",
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

    $.ajax({
        url:"../Master/Default.aspx/getrowcount",
        data:"{}",
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
                         
                       var txtTotal = parseInt(data.d[i].Accept); 
                       if(txtTotal > 10)
                       {
                           jQuery('#div_datascroll').css({"overflow-y": "scroll","overflow-x": "hidden","height": "220px"});
                           //$('#div_datascroll').scrollTop($('#div_datascroll').height());
                           $('#div_datascroll').scrollTop($('#div_datascroll').prop("scrollHeight"));
                       }
                    }
                }
            }
         },
             error:function()
        {}
      });
}

function getrow()
{
    $.ajax({
        url:"../Master/Default.aspx/getrowcount",
        data:"{}",
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
                    Currenttimedisplay();
                        txtTotal = parseInt(data.d[i].Accept); 
                        $('#hdn_getrowcount').val(txtTotal)
                        getinstcount();
                        headertextshow();
                        showuserheader();
                      
                       getmaxmin();
                       // showval_label(MaxMin);
                        getotqty();
                          get_designvalue();
                       // getversion();
                        getversion1();
                        getdescription();
                        showfixture();
                        ReorderExists();
                        setInterval (function (){Currenttimedisplay()},10000);
                    }
                }
            }
         },
             error:function()
        {}
      });
}

function ReorderExists()
{
$.ajax({
        url:"../Master/Default.aspx/Reorderlevel",
        data:"{}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            if(msg.d =="Not Allocated")
            {
                var modal = document.getElementById('myModal1');
                modal.style.display = "block";
                $('#spn_msg1').text('Cell is not ordered');
                 //$('#spn_parthome1').text(msg.d[i].partno1 +'');
            }
            else
            {
                
            }
        },
        error:function()
        {}
   });
}


function Currenttimedisplay() {           
          
      $.ajax({
        url:"../Master/Default.aspx/datetime_current",
        data:"{}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(data)
        {
            if(data!=null && data!="")
            {
                $('#spn_currenttime').text(data.d);
            }
         },
            error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
           }
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
var max='';
var min='';
 
$.ajax({
        url:"../Master/Default.aspx/Get_maxmin",
        data:"{}",
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
            //var dt= $('#hdn_date').val();
            var user=$('#spn_opt').text();
            var shift=$('#spn_Shift').text();
            var sno=$('#Textslno').val();
            var code=$('#Textheatcode').val();
        //    var textvalues=dt+","+shift+","+user;
            var textvalues=shift+","+user;
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
                  
        //    for(var j=6;j<=marph;j++)
        //    {
        //        if($('#txt_value_'+j+''+r+'').is(':disabled'))
        //        {   
        //            textvalues+=",None";
        //        }
        //        else
        //        {
        //            var txt=$('#txt_value_'+j+''+r+'').val();
        //            if(txt=="")
        //            {
        //                $('#txt_value_'+j+''+r+'').css( "background-color","pink" );
        //                alert('ENTER VALUE');
        //                $('#txt_value_'+j+''+r+'').focus();
        //                return;
        //            }
        //            
        //            
        //            else
        //            {
        //                $('#txt_value_'+j+''+r+'').css( "background-color","#fff" );
        //                textvalues+=","+txt;
        //                tot=tot+parseInt(txt);
        //            }
        //            if((j%2)==1)
        //            {
        //                var tot1=tot/2;
        //                tot=0;
        //                avg+=","+tot1;
        //            }
        //        }
        //        
        //    }
        //    for(var z=j;z<=total+1;z++)
        //    {
        //        if($('#txt_value_'+z+''+r+'').is(':disabled'))
        //        {   
        //            textvalues+=",None";
        //        }
        //        else
        //        {
        //            var txt=$('#txt_value_'+z+''+r+'').val();
        //            if(txt=="")
        //            {
        //                $('#txt_value_'+z+''+r+'').css( "background-color","pink" );
        //                alert('ENTER VALUE');
        //                $('#txt_value_'+z+''+r+'').focus();
        //                return;
        //            }
        //            else
        //            {
        //                $('#txt_value_'+z+''+r+'').css( "background-color","#fff" );
        //                textvalues+=","+txt;
        //            }
        //        }
        //    }
           $.ajax({
                    url:"../Master/Default.aspx/TxtbxUpdatevalues",
                    data:"{'Texboxvalues':'"+textvalues+"','Average1':'"+avg+"','ID':'"+id+"'}",
                    type:"POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function(msg)
                    {
                           if(msg.d=="S")
                           {
                             getotqty();
                             getmaxmin();
                             showtxbx();
                             exportoexcel(); 
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
                    var tbl1="<div style='float: left;'><table id='tbleheader' style='border: 0px solid black;border-collapse:collapse;background-color:#eefaff;width='100%' ><tr style='height:30px;background-color:#4C6C9F;'>";
                    var tbl_1="<div style='float: left;'><table id='tbleheader'  style='border: 0px solid black;border-collapse:collapse;background-color:#eefaff;' width='100%'><tr style='height:30px;background-color:#4C6C9F;'><td style='text-align:center;height:10pt;width:100px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>DATE</span></td><td style='text-align:center;height:10pt;width:100px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span style>PID</span></td><td style='text-align:center;height:10pt;width:50px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>SHIFT</span></td><td style='text-align:center;height:10pt;width:100px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>OPERATOR</span></td><td style='text-align:center;height:10pt;width:50px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Sl.No</span></td><td style='text-align:center;height:10pt;width:100px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>HEAT CODE</span></td>";
//                    tbl1+="<td style='text-align: center; height: 10pt; width: 95px; color: #fff; border-right: solid 1px #fff;'class='styleHDR'><span>DATE</span></td>";
//                    tbl1+="<td style='text-align: center; height: 10pt; width: 92px; color: #fff; border-right: solid 1px #fff;'class='styleHDR'><span>PID</span></td>";
//                    tbl1+="<td style='text-align: center; height: 10pt; width: 50px; color: #fff; border-right: solid 1px #fff;'class='styleHDR'><span>SHIFT</span></td>";    
//                    tbl1+="<td style='text-align: center; height: 10pt; width: 92px; color: #fff; border-right: solid 1px #fff;'class='styleHDR'><span>OPERATOR</span></td>";    
//                    tbl1+="<td style='text-align: center; height: 10pt; width: 50px; color: #fff; border-right: solid 1px #fff;'class='styleHDR'><span>Sl.No</span></td>";    
//                    tbl1+="<td style='text-align: center; height: 10pt; width: 98px; color: #fff; border-right: solid 1px #fff;'class='styleHDR'><span>HEAT CODE</span></td>";    
//                    for(var count=0;count<comma.length;count++)
//                    {
//                        if(comma[count]=="")
//                        {
//                        }
//                        else
//                        {
//                        alert(comma[count]);
                            $.ajax({
                                    url:"../Master/Default.aspx/GetheaderQsTxtbx_header",
                                    data:"{}",
                                    type:"POST",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function(msg) {
                                    var cellvalcount=0;
                                   var rowcount= $('#hdn_getrowcount').val();
                                   if (rowcount <=10)
                                   {
                                         for(var k=0;k<msg.d.length;k++)
                                         {
                                                  Mrpval=(msg.d[k].Instrcount);
                                                  if(msg.d[k].Cells !=null && msg.d[k].Cells !="0" && msg.d[k].Cells !="")
                                                  {
                                                  cellvalcount = parseInt(cellvalcount)+parseInt(Mrpval);
                                                    $('#hdn_marph').val(cellvalcount);
                                                     for (var p=1;p<=Mrpval;p++)
                                                      {
                                                       tbl1+='<td colspan="1" style=width:203.5px;">';
                                                       tbl1+='<div style="border:none;"><table style="border:none;"><tr><td style="text-align:center;height:30px;width:101px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>POS1</span></td><td style="text-align:center;height:10pt;width:97px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>POS2</span></td></tr></table></div>';
                                                       tbl1+='</td>';
                                                       tbl_1+='<td style="text-align:center;height:10pt;width:122px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>POS1</span></td><td style="text-align:center;height:10pt;width:105px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>POS2</span></td>';
                                                      }
                                                      
                                                  }
                                                  else
                                                  {
                                                 
                                                     for(var q=1;q<=Mrpval;q++)
                                                      {
                                                      
                                                       tbl1+='<td  style="text-align:center;height:10pt;width:205px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>'+msg.d[k].ShortName+' '+q+'</span></td>';
                                                        tbl_1+='<td style="text-align:center;height:10pt;width:218px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>'+msg.d[k].ShortName+' '+q+'</span></td>';
                                                      }
                                                  }
                                         }
                                         tbl1+="<td style='text-align:center;height:10pt;width:95px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Comments</span></td><td style='text-align:center;height:10pt;width:99px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Time</span></td><td style='text-align:center;height:10pt;width:100px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Action</span></td></tr></table></div>";
                                         tbl_1+="<td style='text-align:center;height:10pt;width:10px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Comments</span></td><td style='text-align:center;height:10pt;width:10px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Time</span></td></tr></table></div>";
                                     }
                                     else{
                                         for(var k=0;k<msg.d.length;k++)
                                         {
                                                  Mrpval=(msg.d[k].Instrcount);
                                                  if(msg.d[k].Cells !=null && msg.d[k].Cells !="0" && msg.d[k].Cells !="")
                                                  {
                                                    $('#hdn_marph').val(Mrpval);
                                                     for (var p=1;p<=Mrpval;p++)
                                                      {
                                                       tbl1+='<td colspan="1" style=width:203.5px;">';
                                                       tbl1+='<div style="border:none;"><table style="border:none;"><tr><td style="text-align:center;height:30px;width:101px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>POS1</span></td><td style="text-align:center;height:10pt;width:97px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>POS2</span></td></tr></table></div>';
                                                       tbl1+='</td>';
                                                       tbl_1+='<td style="text-align:center;height:10pt;width:122px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>POS1</span></td><td style="text-align:center;height:10pt;width:105px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>POS2</span></td>';
                                                      }
                                                      
                                                  }
                                                  else
                                                  {
                                                 
                                                     for(var q=1;q<=Mrpval;q++)
                                                      {
                                                      
                                                       tbl1+='<td  style="text-align:center;height:10pt;width:198.2px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>'+msg.d[k].ShortName+' '+q+'</span></td>';
                                                        tbl_1+='<td style="text-align:center;height:10pt;width:218px;color:#fff;border-right:solid 1px #fff;" class="styleHDR"><span>'+msg.d[k].ShortName+' '+q+'</span></td>';
                                                      }
                                                  }
                                         }
                                         tbl1+="<td style='text-align:center;height:10pt;width:95px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Comments</span></td><td style='text-align:center;height:10pt;width:99px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Time</span></td><td style='text-align:center;height:10pt;width:100px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Action</span></td></tr></table></div>";
                                         tbl_1+="<td style='text-align:center;height:10pt;width:10px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Comments</span></td><td style='text-align:center;height:10pt;width:10px;color:#fff;border-right:solid 1px #fff;' class='styleHDR'><span>Time</span></td></tr></table></div>";
                                     }
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

function isNumber(evt, element) {

var charCode = (evt.which) ? evt.which : event.keyCode

if (charCode > 31 && 
    (charCode != 45 || $(element).val().indexOf('-') != -1) &&      // “-” CHECK MINUS, AND ONLY ONE.
    (charCode != 46 || $(element).val().indexOf('.') != -1) &&      // “.” CHECK DOT, AND ONLY ONE.
    (charCode < 48 || charCode > 57)){
    alert("Accept only number !!");
    return false;
    }
    else{
    return true;
    }
} 
    
function onlyNumbers_slno(evt) {
    var e = event || evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)){
    alert("Accept only number !!");
        return false;
        }
        else{
    return true;
    }
}

function isNumber_QS(evt, element) {

var charCode = (evt.which) ? evt.which : event.keyCode

if (charCode > 31 && 
    (charCode != 45 || $(element).val().indexOf('-') != -1) &&      // “-” CHECK MINUS, AND ONLY ONE.
    (charCode != 46 || $(element).val().indexOf('.') != -1) &&      // “.” CHECK DOT, AND ONLY ONE.
    (charCode < 48 || charCode > 57) && (charCode != 111 && charCode != 107 && charCode != 110 && charCode != 116 && charCode != 32) ){
    alert("Enter Correct dimension values (OR) Enter OK/NOTOK");
    $(element).val('');
    return false;
    }
    else{
    return true;
    }
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
var QSlno="1";
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
                  
try {

 $.ajax({
        url:"../Master/Default.aspx/getuserdetailval",
        data:"{}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(data) {
        
        var str=data.d;
        var arr = str.split(',');
        if(arr.length == 7)
        {
//         QDate=Qsdate;
         QDate=arr[0];
         $('#hdn_date').val(QDate);
         QPidno=arr[1];
         QShift=arr[2];
         QOPERATOR=arr[3];
         //QSlno=arr[7];
         $('#spn_partno').text(arr[4]);
         $('#spn_prdpin1').text(arr[4]);
         $('#hdn_partno').val(arr[4]);
         $('#hdn_pidno').val(arr[1]);
         $('#hdn_shift').val(arr[2]);
         $('#hdn_operation').val(arr[5]);
         $('#spn_machine').text(arr[6]);
         $('#spn_mach1').text(arr[6]);
         var cout=0;
         var d=1;
         var celcnt=0;
         var celvalcnt=0;         
         var celcounting=0;
         var rowcount= $('#hdn_getrowcount').val();
         if(rowcount <=10)
         {
         var tbl="<div style='margin-left:-486.5px;'> <table id='tblqualitysheet' style='border: 0px solid black;border-collapse: collapse;background-color:#eefaff;' width='100%'><tr><td style='text-align:center;height:20pt;width:95px;' class='styleHDR'><span id='spn_date'>"+QDate+"</span></td><td style='border: 1px solid black;width:0px;'><input type='text' id='Text_pidno' style='width:90px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;' class='MrpTxtBox_dyn5' /></td><td style='text-align:center;height:10pt;width:60px;' class='styleHDR'><span id='spn_Shift'>"+QShift+"</span></td><td style='text-align:center;height:10pt;width:100px;' class='styleHDR'><span id='spn_opt'>"+QOPERATOR+"</span></td><td style='border: 1px solid black;'><input type='text' id='Textslno' style='width:50px;height: 15pt;border:none;background-color:#f7dff0;' class='specTxtbx' onkeypress='return onlyNumbers_slno(this);' /></td><td style='border: 1px solid black;'><input type='text' id='Textheatcode' style='width:85px;height: 15pt;border:none;background-color:#f7dff0;' class='specTxtbx' /></td>";
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
                     
                            celcnt = celcnt + parseInt(msg.d[k].Cells)
                                 if(msg.d[k].Frequency == "1/5 Parts")
                                 {
                                         for(var i=1;i<=Mrpval*2;i++)
                                          {
                                             cout+=1;
                                             tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="MrpTxtBox_dyn5" onkeypress="return isNumber_QS(event, this);" onblur="javascript:changeothertab('+cout+','+msg.d[k].Id+','+i+');"' ;
                                             if((tid% 5) == 0)
                                              {
                                                tbl+=' style="width:95px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                              }
                                              else
                                              {
                                               
                                             //   tbl+='disabled="disabled" style="width:95px;height: 15pt;background-color:gray;border:none;text-align:center;" /></td>';
                                                  tbl+='style="width:95px;height: 15pt;background-color:#f7dff0;;border:none;text-align:center;" /></td>';
                                                
                                              }
                                          }
                                          
                                    }
                                    else if(msg.d[k].Frequency  == "1/10 Parts")
                                     { 
                                             for(var i=1;i<=Mrpval*2;i++)
                                              {
                                               cout+=1;
                                                 tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="MrpTxtBox_dyn5" onkeypress="return isNumber_QS(event, this);" onblur="javascript:changeothertab('+cout+','+msg.d[k].Id+','+i+');"' ;
                                                 if((tid% 10) == 0)
                                                  {
                                                    tbl+=' style="width:95px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                                  }
                                                  else
                                                  {
                                                   
                                                   // tbl+='disabled="disabled" style="width:95px;height: 15pt;background-color:gray;border:none;text-align:center;" /></td>';
                                                     tbl+='style="width:95px;height: 15pt;background-color:#f7dff0;;border:none;text-align:center;" /></td>';
                                                  }
                                              }
                                     }
                                     else if(msg.d[k].Frequency  == "1/15 Parts")
                                     {
                                            for(var i=1;i<=Mrpval*2;i++)
                                              {
                                                cout+=1;
                                                 tbl+='<td style="border: 1px solid black;"><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="MrpTxtBox_dyn5" onkeypress="return isNumber_QS(event, this);" onblur="javascript:changeothertab('+cout+','+msg.d[k].Id+','+i+');" ' ;
                                                 if((tid% 15) == 0)
                                                  {
                                                    tbl+=' style="width:95px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                                  }
                                                  else
                                                  {
                                                   
                                                    tbl+='style="width:95px;height: 15pt;background-color:#f7dff0;;border:none;text-align:center;" /></td>';
                                                  //  tbl+='disabled="disabled" style="width:95px;height: 15pt;background-color:gray;border:none;text-align:center;" /></td>';
                                                  }
                                              }
                                      }
                                      
                                      else
                                      {
                                              
                                              for(var i=1;i<=Mrpval*2;i++)
                                              {
                                              
                                                if(i % 2 ==1)
                                                {
                                                    celcounting=celcnt +1;
                                                    d+=1;
                                                }
                                                else
                                                {
                                                }
                                                tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" style="width:95px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" class="MrpTxtBox_dyn" onkeypress="return isNumber_QS(event, this);" onblur="javascript:checkrange('+celcounting+','+msg.d[k].Id+','+i+');"/></td>' ;
                                                //tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" style="width:95px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" class="MrpTxtBox_dyn" onkeypress="return isNumber_QS(event, this);" onblur="javascript:checkrange('+d+','+msg.d[k].Id+','+i+');"/></td>' ;
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
                                            cout+=1;
                                            tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="RghTxtBox_dyn5" onkeypress="return isNumber_QS(event, this);" onblur="javascript:changeothertab('+cout+','+msg.d[k].Id+','+i+');"' ;
                                             if ((tid% 5) == 0)
                                              {
                                               
                                              tbl+=' style="width:195px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                              }
                                              else
                                              {
                                            //  tbl+='disabled="disabled"  style="width:197px;height: 15pt;background-color:gray;border:none" /></td>';
                                               tbl+='style="width:195px;height: 15pt;background-color:#f7dff0;;border:none" /></td>';
                                              }
                                          }
                                   }
                                  else if(msg.d[k].Frequency == "1/10 Parts")
                                  { 
                                          for(var i=1;i<=Mrpval;i++)
                                          {
                                            cout+=1;
                                             tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="RghTxtBox_dyn5" onkeypress="return isNumber_QS(event, this);" onblur="javascript:changeothertab('+cout+','+msg.d[k].Id+','+i+');" ' ;
                                             if ((tid% 10) == 0)
                                              {
                                              tbl+=' style="width:195px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                              }
                                              else
                                              {
                                            //  tbl+='disabled="disabled"  style="width:197px;height: 15pt;background-color:gray;border:none" /></td>';
                                                 tbl+='style="width:195px;height: 15pt;background-color:#f7dff0;;border:none" /></td>';
                                              }
                                          }
                                     }
                                    else if(msg.d[k].Frequency == "1/15 Parts")
                                    {
                                        for(var i=1;i<=Mrpval;i++)
                                        {
                                            cout+=1;
                                             tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="RghTxtBox_dyn5" onkeypress="return isNumber_QS(event, this);" onblur="javascript:changeothertab('+cout+','+msg.d[k].Id+','+i+');" ' ;
                                             if ((tid% 15) == 0)
                                              {
                                              tbl+=' style="width:195px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                              }
                                              else
                                              {
                                           //  tbl+='disabled="disabled"  style="width:197px;height: 15pt;background-color:gray;border:none" /></td>';
                                             tbl+='style="width:195px;height: 15pt;background-color:#f7dff0;;border:none" /></td>';
                                              }
                                          }
                                    }
                                    else
                                    {
                                         for(var i=1;i<=Mrpval;i++)
                                          {
                                            cout+=1;
                                              tbl+='<td  style="border: 1px solid black; " ><input  type="text" id="txt_'+msg.d[k].Id+''+i+'" style="width:194.5px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" class="RghTxtBox_dyn" onkeypress="return isNumber_QS(event, this);" onblur="javascript:changeothertab('+cout+','+msg.d[k].Id+','+i+');" /></td>' ;
                                              rghvalue++;
                                             
                                          }

                                    }
                        }
                                    
                        }
                       
             }
               tbl+="<td style='border: 1px solid black;'><input type='text' id='textcmt' style='width:91px;height: 15pt;border:none;' class='TxtBox_dyn9'/></td><td style='border: 1px solid black;width:100px;height: 15pt;'><span id='span_time'></span></td><td style='border: 1px solid black;width:97.5px;height: 15pt;' id='td_add'><img src='../images/add.png'  alt='Submit'  id='btn_Save' style='margin-left:35px;cursor:pointer;' onclick='javascript:Save();'/></td></tr></table></div>";
                 $("#div_tab").html(tbl);
                  //$("#btn_Save").bind("click", Save);
               
                $('#Text_pidno').focus(); 
                  
            },
            error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
                }
          });
          }
          else{
          
          var tbl="<div style='margin-left:-486.5px;'> <table id='tblqualitysheet' style='border: 0px solid black;border-collapse: collapse;background-color:#eefaff;' width='100%'><tr><td style='text-align:center;height:20pt;width:95px;' class='styleHDR'><span id='spn_date'>"+QDate+"</span></td><td style='border: 1px solid black;width:0px;'><input type='text' id='Text_pidno' style='width:90px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;' class='MrpTxtBox_dyn5' /></td><td style='text-align:center;height:10pt;width:60px;' class='styleHDR'><span id='spn_Shift'>"+QShift+"</span></td><td style='text-align:center;height:10pt;width:100px;' class='styleHDR'><span id='spn_opt'>"+QOPERATOR+"</span></td><td style='border: 1px solid black;'><input type='text' id='Textslno' style='width:50px;height: 15pt;border:none;background-color:#f7dff0;' class='specTxtbx' onkeypress='return onlyNumbers_slno(this);' /></td><td style='border: 1px solid black;'><input type='text' id='Textheatcode' style='width:75px;height: 15pt;border:none;background-color:#f7dff0;' class='specTxtbx' /></td>";
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
                                             cout+=1;
                                             tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="MrpTxtBox_dyn5" onkeypress="return isNumber_QS(event, this);" onblur="javascript:changeothertab('+cout+','+msg.d[k].Id+','+i+');"' ;
                                             if((tid% 5) == 0)
                                              {
                                                tbl+=' style="width:90px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                              }
                                              else
                                              {
                                               
                                             //   tbl+='disabled="disabled" style="width:95px;height: 15pt;background-color:gray;border:none;text-align:center;" /></td>';
                                                  tbl+='style="width:90px;height: 15pt;background-color:#f7dff0;;border:none;text-align:center;" /></td>';
                                                
                                              }
                                          }
                                          
                                    }
                                    else if(msg.d[k].Frequency  == "1/10 Parts")
                                     { 
                                             for(var i=1;i<=Mrpval*2;i++)
                                              {
                                               cout+=1;
                                                 tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="MrpTxtBox_dyn5" onkeypress="return isNumber_QS(event, this);" onblur="javascript:changeothertab('+cout+','+msg.d[k].Id+','+i+');"' ;
                                                 if((tid% 10) == 0)
                                                  {
                                                    tbl+=' style="width:90px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                                  }
                                                  else
                                                  {
                                                   
                                                   // tbl+='disabled="disabled" style="width:95px;height: 15pt;background-color:gray;border:none;text-align:center;" /></td>';
                                                     tbl+='style="width:90px;height: 15pt;background-color:#f7dff0;;border:none;text-align:center;" /></td>';
                                                  }
                                              }
                                     }
                                     else if(msg.d[k].Frequency  == "1/15 Parts")
                                     {
                                            for(var i=1;i<=Mrpval*2;i++)
                                              {
                                                cout+=1;
                                                 tbl+='<td style="border: 1px solid black;"><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="MrpTxtBox_dyn5" onkeypress="return isNumber_QS(event, this);" onblur="javascript:changeothertab('+cout+','+msg.d[k].Id+','+i+');" ' ;
                                                 if((tid% 15) == 0)
                                                  {
                                                    tbl+=' style="width:90px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                                  }
                                                  else
                                                  {
                                                   
                                                    tbl+='style="width:90px;height: 15pt;background-color:#f7dff0;;border:none;text-align:center;" /></td>';
                                                  //  tbl+='disabled="disabled" style="width:95px;height: 15pt;background-color:gray;border:none;text-align:center;" /></td>';
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
                                                tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" style="width:95px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" class="MrpTxtBox_dyn" onkeypress="return isNumber_QS(event, this);" onblur="javascript:checkrange('+d+','+msg.d[k].Id+','+i+');"/></td>' ;
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
                                            cout+=1;
                                            tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="RghTxtBox_dyn5" onkeypress="return isNumber_QS(event, this);" onblur="javascript:changeothertab('+cout+','+msg.d[k].Id+','+i+');"' ;
                                             if ((tid% 5) == 0)
                                              {
                                               
                                              tbl+=' style="width:193.5px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                              }
                                              else
                                              {
                                            //  tbl+='disabled="disabled"  style="width:197px;height: 15pt;background-color:gray;border:none" /></td>';
                                               tbl+='style="width:193.5px;height: 15pt;background-color:#f7dff0;;border:none" /></td>';
                                              }
                                          }
                                   }
                                  else if(msg.d[k].Frequency == "1/10 Parts")
                                  { 
                                          for(var i=1;i<=Mrpval;i++)
                                          {
                                            cout+=1;
                                             tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="RghTxtBox_dyn5" onkeypress="return isNumber_QS(event, this);" onblur="javascript:changeothertab('+cout+','+msg.d[k].Id+','+i+');" ' ;
                                             if ((tid% 10) == 0)
                                              {
                                              tbl+=' style="width:193.5px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                              }
                                              else
                                              {
                                            //  tbl+='disabled="disabled"  style="width:197px;height: 15pt;background-color:gray;border:none" /></td>';
                                                 tbl+='style="width:193.5px;height: 15pt;background-color:#f7dff0;;border:none" /></td>';
                                              }
                                          }
                                     }
                                    else if(msg.d[k].Frequency == "1/15 Parts")
                                    {
                                        for(var i=1;i<=Mrpval;i++)
                                        {
                                            cout+=1;
                                             tbl+='<td style="border: 1px solid black;" ><input type="text" id="txt_'+msg.d[k].Id+''+i+'" class="RghTxtBox_dyn5" onkeypress="return isNumber_QS(event, this);" onblur="javascript:changeothertab('+cout+','+msg.d[k].Id+','+i+');" ' ;
                                             if ((tid% 15) == 0)
                                              {
                                              tbl+=' style="width:193.5px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" /></td>';
                                              }
                                              else
                                              {
                                           //  tbl+='disabled="disabled"  style="width:197px;height: 15pt;background-color:gray;border:none" /></td>';
                                             tbl+='style="width:193.5px;height: 15pt;background-color:#f7dff0;;border:none" /></td>';
                                              }
                                          }
                                    }
                                    else
                                    {
                                         for(var i=1;i<=Mrpval;i++)
                                          {
                                            cout+=1;
                                              tbl+='<td  style="border: 1px solid black; " ><input  type="text" id="txt_'+msg.d[k].Id+''+i+'" style="width:193.5px;height: 15pt;border:none;text-align:center;background-color:#f7dff0;" class="RghTxtBox_dyn" onkeypress="return isNumber_QS(event, this);" onblur="javascript:changeothertab('+cout+','+msg.d[k].Id+','+i+');" /></td>' ;
                                              rghvalue++;
                                             
                                          }

                                    }
                        }
                                    
                        }
                       
             }
               tbl+="<td style='border: 1px solid black;'><input type='text' id='textcmt' style='width:90px;height: 15pt;border:none;' class='TxtBox_dyn9'/></td><td style='border: 1px solid black;width:103px;height: 15pt;'><span id='span_time'></span></td><td style='border: 1px solid black;width:105px;height: 15pt;' id='td_add'><img src='../images/add.png'  alt='Submit'  id='btn_Save' style='margin-left:35px;cursor:pointer;' onclick='javascript:Save();'/></td></tr></table></div>";
                 $("#div_tab").html(tbl);
                  //$("#btn_Save").bind("click", Save);
               
                $('#Text_pidno').focus(); 
                  
            },
            error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
                }
          });
          }
          }
          else
          {
              var error = data.d;
              alert(error);
          }
         },
         error: function (xhr, ajaxOptions, thrownError) {
        alert(xhr.status);
        alert(thrownError);
        }
        });
    }
    catch(err) {
        message.innerHTML = "Input is " + err;
    }
               
                             
}

$('#textcmt').live('keydown', function(e) {
    if (e.keyCode === 9) {
        e.preventDefault();
        // do work
//       document.getElementById("btn_Save").focus();
//       document.getElementById("btn_Save").scrollIntoView();
var ele = document.getElementById("btn_Save");
   ele.scrollIntoView();
   ele.tabIndex = -1;
   ele.focus();
    }
});

$('#btn_Save').live('keydown', function(event) {
    if(event.keyCode == 13){
        $("#btn_Save").click();
    }
});

 function Save()
 {

 
    var st='';
    var st1='';
if(($('#Textslno').val()=="")||(st==""))
{
//
//  alert('Please Wait');
}

if(($('#Textslno').val()!="")||(f!=""))
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
                                                textvalues+=",None";
                                            }
                                            else
                                            {
                                          
                                                var txt=$('#txt_'+msg.d[c].Id+''+m+'').val();
//                                            
//                                                 if((txt=="")&&(msg.d[c].Instruments != "CMM")&&(msg.d[c].Instruments != "CMM1")&&(msg.d[c].Instruments != "PROFILE TESTER")&&(msg.d[c].Instruments != "MAHR ROUNDNESS TESTER") && (msg.d[c].Instruments != "CONTOUR")&& (msg.d[c].Instruments != "FORM MACHINE") )
                                              
                                                if((txt==""))
                                                {
                                              
//                                                   if((msg.d[c].Instruments =="CMM")||(msg.d[c].Instruments == "CMM1")||(msg.d[c].Instruments == "PROFILE TESTER")||(msg.d[c].Instruments == "MAHR ROUNDNESS TESTER") || (msg.d[c].Instruments == "CONTOUR")|| (msg.d[c].Instruments == "FORM MACHINE"))
//                                                {
//                                                   $('#txt_'+msg.d[c].Id+''+m+'').val('-');
//                                                   txt= $('#txt_'+msg.d[c].Id+''+m+'').val();
//                                                    $('#txt_'+msg.d[c].Id+''+m+'').css( "background-color","#fff" );
//                                                    textvalues+=","+txt;
//                                                   
//                                                }
//                                                
//                                                else
//                                                {
//                                                
//                                                    $('#txt_'+msg.d[c].Id+''+m+'').css( "background-color","pink" );
//                                                    alert('ENTER '+msg.d[c].Instruments+' VALUE');
//                                                    $('#txt_'+msg.d[c].Id+''+m+'').focus();
//                                                    return;
//                                                    }

                                                     if((msg.d[c].Frequency =="100%"))
                                                     {
                                                       $('#txt_'+msg.d[c].Id+''+m+'').css( "background-color","pink" );
                                                        alert('ENTER '+msg.d[c].Instruments+' VALUE');
                                                        $('#txt_'+msg.d[c].Id+''+m+'').focus();
                                                        return;
                                                     }
                                                     else
                                                     {
                                                         $('#txt_'+msg.d[c].Id+''+m+'').val('-');
                                                         txt= $('#txt_'+msg.d[c].Id+''+m+'').val();
                                                         $('#txt_'+msg.d[c].Id+''+m+'').css( "background-color","#fff" );
                                                         textvalues+=","+txt;
                                                     }
                                                }
                                                else
                                                {
                                                    $('#txt_'+msg.d[c].Id+''+m+'').css( "background-color","#fff" );
                                                    textvalues+=","+txt;
                                                    tot=tot+parseFloat(txt);
                                                }
                                                if((m%2)==0)
                                                {   
                                                    if(isNaN(tot))
                                                    {
                                                        tot = 0;
                                                    }
                                                    var tot1=parseFloat(tot)/parseFloat(2);
                                                    if(isNaN(tot1))
                                                    {
                                                        tot1 = 0;
                                                    }
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
                                                textvalues+=",None";
                                            }
                                            else
                                            {
                                                var txt=$('#txt_'+msg.d[c].Id+''+m+'').val();
                                              //  ////
//                                                 if((txt=="")&&(msg.d[c].Instruments != "CMM")&&(msg.d[c].Instruments != "CMM1")&&(msg.d[c].Instruments != "PROFILE TESTER")&&(msg.d[c].Instruments != "MAHR ROUNDNESS TESTER") && (msg.d[c].Instruments != "CONTOUR")&& (msg.d[c].Instruments != "FORM MACHINE") )
//                                               
//                                                {
                                               if((txt==""))
                                               {
                                             
//                                                  if((msg.d[c].Instruments =="CMM")||(msg.d[c].Instruments == "CMM1")||(msg.d[c].Instruments == "PROFILE TESTER")||(msg.d[c].Instruments == "MAHR ROUNDNESS TESTER") || (msg.d[c].Instruments == "CONTOUR")|| (msg.d[c].Instruments == "FORM MACHINE") )
//                                                {
//                                                  
//                                                   $('#txt_'+msg.d[c].Id+''+m+'').val('-');
//                                                   txt=  $('#txt_'+msg.d[c].Id+''+m+'').val();
//                                                    $('#txt_'+msg.d[c].Id+''+m+'').css( "background-color","#fff" );
//                                                    textvalues+=","+txt;
//                                                }
//                                                
//                                                else
//                                                {
//                                                
//                                                   $('#txt_'+msg.d[c].Id+''+m+'').css( "background-color","pink" );
//                                                   
//                                                   alert('ENTER '+msg.d[c].Instruments+' VALUE');
//                                                   $('#txt_'+msg.d[c].Id+''+m+'').focus();
//                                                   return;
//                                                   
//                                                }


                                                    if((msg.d[c].Frequency =="100%"))
                                                    {
                                                       $('#txt_'+msg.d[c].Id+''+m+'').css( "background-color","pink" );
                                                       alert('ENTER '+msg.d[c].Instruments+' VALUE');
                                                       $('#txt_'+msg.d[c].Id+''+m+'').focus();
                                                       return;
                                                    }
                                                    else
                                                    {
                                                       $('#txt_'+msg.d[c].Id+''+m+'').val('-');
                                                       txt= $('#txt_'+msg.d[c].Id+''+m+'').val().trim();
                                                       $('#txt_'+msg.d[c].Id+''+m+'').css( "background-color","#fff" );
                                                       textvalues+=","+txt;
                                                    }
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
                                try {
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
                                            var str=msg.d;
                                            var arr = str.split(',');
                                            
                                            if(arr[0]=="S")
                                            {
                                                excel=1;
                                                st1="t";
                                                $('#Textslno').val('');
                                                st= $('#Textslno').val();
                                                getotqty();
                                                getmaxmin();
                                                showtxbx();
                                                hideLayer();
                                                //exportoexcel(); 
                                                showfixture();
                                                $('#Text_pidno').focus();
                                            }
                                            if(arr[1]=="A")
                                            {
                                                alert('Shift changed from C to A. Data will load according to A shift');
                                            }
                                            else if(arr[1]=="B")
                                            {
                                                alert('Shift changed from A to B. Data will load according to B shift');
                                            }
                                            else if(arr[1]=="C")
                                            {
                                                alert('Shift changed from B to C. Data will load according to C shift');
                                            }
                                        },
                                        error: function (xhr, ajaxOptions, thrownError) {
                                            alert(xhr.status);
                                            alert(thrownError);
                                            var err = eval("(" + xhr.responseText + ")");
                                            alert(err.Message);
                                            }
                                        });
                                        
                                            }
                                    catch(err) {
                                        message.innerHTML = "Input is " + err;
                                    }
                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                        alert(xhr.status);
                        alert(thrownError);
                        var err = eval("(" + xhr.responseText + ")");
                        alert(err.Message);
                        }
                 });
                 
    }
 
 }
function Chart()
{
document.getElementById("btn_chart").click();
}
function exportoexcel()
{

            var html = '';
            html += $("#div_livedata").html();
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

function exportoexcel1()
{
        var html = '';
        html += $("#div_livedata").html();
        html = $.trim(html);
        html = html.replace(/>/g, '&gt;');
        html = html.replace(/</g, '&lt;');
        $('#hdn_excel').val(html);
        document.getElementById("btn_excel").click();
        alert('Saved Successfully');
        return false;
}
function headertextshow()
{
    var tbl='<table style=" border-collapse: collapse; width="100%" ><tr style="background-color:#4C6C9F;border:solid 1px #fff;">';
    var ttbbl='<div style=""><table style=" border-collapse: collapse; width="100%" ><tr style="background-color:#4C6C9F;border:solid 1px #fff;"><td class="style58" colspan="6" style="text-align:center; width:500px; background-color: #4C6C9F; color: #fff; border-bottom: solid 1.4px #fff;"><span>Instruments</span> </td>';
    $.ajax({
            url:"../Master/Default.aspx/GetheaderQsTxtbx_header",
            data:"{}",
            type:"POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(msg) {
                  for(var i=0;i<msg.d.length;i++)
                  {
                      var rowcount= $('#hdn_getrowcount').val();
                      if (rowcount<10)
                      {
                        if(msg.d[i].Cells!=null  && msg.d[i].Cells!="0" && msg.d[i].Cells!="")
                        {
                           var width=parseInt(msg.d[i].Instrcount);
                           var col=parseInt(width)*(1);
                           var col1=parseInt(width)*(2);
                           width=parseInt(width)*(201);
                           var w='width:'+width+'px;';
                           tbl+='<td   colspan='+col+' style="text-align:center;white-space:normal;margin-right:40px;height:16pt;color:#fff;border:solid 1.6px #fff;'+w+'" class="styleHDR"> <div style="border-bottom:1px solid #fff;"><span style="color:#FFE4C4;">' + msg.d[i].Headername + '</span></div><div><span span style="color:#FAF0E6;" id=span1_'+msg.d[i].id+'>' + msg.d[i].Instruments + '</span></div> </td>';
                           ttbbl+='<td  colspan='+col1+' style="text-align:center;white-space:normal;margin-right:40px;height:16pt;color:#fff;border:solid 1.6px #fff;'+w+'" class="styleHDR"> <div style="border-bottom:1px solid #fff;"><span style="color:#FFE4C4;">' + msg.d[i].Headername + '</span></div><div><span span style="color:#FAF0E6;" id=span1_'+msg.d[i].id+'>' + msg.d[i].Instruments + '</span></div> </td>';
                        }
                        else
                        {
                           var width=parseInt(msg.d[i].Instrcount);
                           var col=parseInt(width)*(1);
                           width=parseInt(width)*(198.3);
                           var w='width:'+width+'px;';
                           tbl+='<td ='+col+' style="text-align:center;white-space:normal;margin-right:40px;height:16pt;color:#fff;border:solid 1.6px #fff;'+w+'" class="styleHDR"> <div style="border-bottom:1px solid #fff;"><span style="color:#FFE4C4;">' + msg.d[i].Headername + '</span></div><div><span span style="color:#FAF0E6;" id=span1_'+msg.d[i].id+'>' + msg.d[i].Instruments + '</span></div> </td>';
                           ttbbl+='<td  colspan='+col+' style="text-align:center; white-space:normal;margin-right:40px; height:16pt;color:#fff;border:solid 1.6px #fff;'+w+'" class="styleHDR"> <div style="border-bottom:1px solid #fff;"><span style="color:#FFE4C4;">' + msg.d[i].Headername + '</span></div><div><span span style="color:#FAF0E6;" id=span1_'+msg.d[i].id+'>' + msg.d[i].Instruments + '</span></div> </td>';
                        }
                    }
                    else
                    {
                        if(msg.d[i].Cells!=null  && msg.d[i].Cells!="0" && msg.d[i].Cells!="")
                        {
                           var width=parseInt(msg.d[i].Instrcount);
                           var col=parseInt(width)*(1);
                           var col1=parseInt(width)*(2);
                           width=parseInt(width)*(201);
                           var w='width:'+width+'px;';
                           tbl+='<td   colspan='+col+' style="text-align:center;white-space:normal;margin-right:40px;height:16pt;color:#fff;border:solid 1.6px #fff;'+w+'" class="styleHDR"> <div style="border-bottom:1px solid #fff;"><span style="color:#FFE4C4;">' + msg.d[i].Headername + '</span></div><div><span span style="color:#FAF0E6;" id=span1_'+msg.d[i].id+'>' + msg.d[i].Instruments + '</span></div> </td>';
                           ttbbl+='<td  colspan='+col1+' style="text-align:center;white-space:normal;margin-right:40px;height:16pt;color:#fff;border:solid 1.6px #fff;'+w+'" class="styleHDR"> <div style="border-bottom:1px solid #fff;"><span style="color:#FFE4C4;">' + msg.d[i].Headername + '</span></div><div><span span style="color:#FAF0E6;" id=span1_'+msg.d[i].id+'>' + msg.d[i].Instruments + '</span></div> </td>';
                        }
                        else
                        {
                           var width=parseInt(msg.d[i].Instrcount);
                           var col=parseInt(width)*(1);
                           width=parseInt(width)*(197.5);
                           var w='width:'+width+'px;';
                           tbl+='<td ='+col+' style="text-align:center;white-space:normal;margin-right:40px;height:16pt;color:#fff;border:solid 1.6px #fff;'+w+'" class="styleHDR"> <div style="border-bottom:1px solid #fff;"><span style="color:#FFE4C4;">' + msg.d[i].Headername + '</span></div><div><span span style="color:#FAF0E6;" id=span1_'+msg.d[i].id+'>' + msg.d[i].Instruments + '</span></div> </td>';
                           ttbbl+='<td  colspan='+col+' style="text-align:center; white-space:normal;margin-right:40px; height:16pt;color:#fff;border:solid 1.6px #fff;'+w+'" class="styleHDR"> <div style="border-bottom:1px solid #fff;"><span style="color:#FFE4C4;">' + msg.d[i].Headername + '</span></div><div><span span style="color:#FAF0E6;" id=span1_'+msg.d[i].id+'>' + msg.d[i].Instruments + '</span></div> </td>';
                        }
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
//                    }
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
                            ////
                                 $('#spn_machinename').text(msg.d[i].Machinename);  
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
    var version=$('#spn_version').text();
    var s='';
$.ajax({
                url:"../Master/Default.aspx/get_sheetversion",
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
                            if(msg.d[i].filename==null || msg.d[i].filename=="")
                            {
                                $('#spn_filename').text('File Name Not Found');
                            }
                            else
                            {
                                $('#spn_filename').text(msg.d[i].filename);
                            }
                            $('#spn_createby').text(msg.d[i].creatby);
                          //  $('#spn_vcreate').text(msg.d[i].creatby);
                            if(version==msg.d[i].version || version=="")
                            {
                                $('#spn_version').text(msg.d[i].version);
                               // $('#spn_vversion').text(msg.d[i].version);
                                $('#spn_createdate').text(msg.d[i].date);
                               // $('#spn_vdate').text(msg.d[i].date);
                            } 
                            else
                            {
                                 $('#spn_version').text(msg.d[i].version);
                               //  $('#spn_vversion').text(msg.d[i].version);
                                 $('#spn_createdate').text(msg.d[i].date);
                               //  $('#spn_vdate').text(msg.d[i].date);
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
        getrow();

//***********not need**********

//        getinstcount();
//        headertextshow();
//        showuserheader();
//      
//       getmaxmin();
//       // showval_label(MaxMin);
//        getotqty();
//          get_designvalue();
//       // getversion();
//        getversion1();
//        getdescription();
//        showfixture();

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
//   var values1=$('#txt_value_'+name+''+dd+'').val();
var  vis=$('#txt_'+name+''+dd+'').val();
values=values.trim();
vis=vis.trim();
values=parseFloat(values);
var _count=parseInt(id);
var oth=other[_count];

var mmin=minother[_count];
var mmean=meanother[_count];
var mpmean=Pmean[_count];
var maxCL=ucl[_count];
var minCL=lcl[_count];
var minCL=lcl[_count];
var Rchart=runchart[_count];

    if(Rchart=="Yes")
    {
        if(parseInt($('#hdnrowid').val()) >= parseInt(6) && values !="")
        {
        $.ajax({
                url:"../Master/Default.aspx/Sevenoneside",
                data:"{'Crnttxtvalue':'"+values+"','dynrefid':'"+name+"','inst_count':'"+dd+"','UCL':'"+maxCL+"','Mean':'"+mmean+"','LCL':'"+minCL+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg!=null && msg!="")
                    {
                        if(msg.d=="L")
                        {
                            alert('Seven (or) more points in Lower Side of the Chart');
                        }
                        if(msg.d=="U")
                        {
                            alert('Seven (or) more points in Upper Side of the Chart');
                        }
                        if(msg.d=="MDown")
                        {
                            alert('Seven (or) more points Moving Down');
                        }
                        if(msg.d=="MUp")
                        {
                            alert('Seven (or) more points Moving Up');
                        }
                    }
                },
                error:function()
                {}
              });
         }

        if(values > parseFloat(maxCL))
        {
            alert('Points outside the Upper Control Limit');
        }
        if(values < parseFloat(minCL))
        {
            alert('Points outside the Lower Control Limit');
        }
    }
    
     if(values > parseFloat(oth)|| values < parseFloat(mmin) || vis == "not ok"|| vis =="notok" || vis =="NOT OK" || vis =="NOTOK")
    //  if(values > parseFloat(oth))
     {
      $('#txt_'+name+''+dd+'').css({"background-color": "red"});
        
     }
     else if (vis == "-")
     {
       $('#txt_'+name+''+dd+'').css({"background-color": "orange"});
     }
     else
     {
        $('#txt_'+name+''+dd+'').css({"background-color": "#f7dff0"});
     }
 }
 function changeothertab1(id,name,dd)
 {
var values=$('#txt_value_'+name+''+dd+'').val();
var  vis=$('#txt_value_'+name+''+dd+'').val();
var _count=parseInt(id);
var oth=other[_count];
values=parseFloat(values);
var mmin=minother[_count];
var maxCL=ucl[_count];
var minCL=lcl[_count];
var mpmean=Pmean[_count];
var Rchart=runchart[_count];

    if(Rchart=="Yes")
    {
        if(values > parseFloat(maxCL))
        {
            alert('Points outside the Upper Control Limit');
        }
        if(values < parseFloat(minCL))
        {
            alert('Points outside the Lower Control Limit');
        }
    }
    
   if(values > parseFloat(oth)|| values < parseFloat(mmin) || vis == "not ok"|| vis =="notok" || vis =="NOT OK" || vis =="NOTOK")
    //  if(values > parseFloat(oth))
     {
      $('#txt_value_'+name+''+dd+'').css({"background-color": "red"});
        
     }
     else if (vis == "-")
     {
       $('#txt_'+name+''+dd+'').css({"background-color": "orange"});
     }
     else
     {
        $('#txt_value_'+name+''+dd+'').css({"background-color": "#f7dff0"});
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
 
// getpartDesc
function getdescription()
{

$.ajax({
        url:"../Master/Default.aspx/getpartdesc",
        data:"{}",
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

function dyngridload()
{
    
    $.ajax({
        type: "POST",
        url: "../Master/DYNMaster.aspx/getfullgrid",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function (response) {
        
            alert(response.d);
            alert('f');
        },
        error: function (response) {
        
            alert(response.d);
            alert('e');
        }
    });
   
 
    function OnSuccess(response) {
    
        var xmlDoc = $.parseXML(response.d);
        var xml = $(xmlDoc);
        var customers = xml.find("Table");
        var row = $("[id*=grd_dynmaster] tr:last-child").clone(true);
        $("[id*=grd_dynmaster] tr").not($("[id*=grd_dynmaster] tr:first-child")).remove();
        $.each(customers, function () {
            var customer = $(this);
            $("td", row).eq(0).html($(this).find("RowNumber").text());
            $("td", row).eq(1).html($(this).find("Partno").text());
            $("td", row).eq(2).html($(this).find("Operation").text());
            $("td", row).eq(3).html($(this).find("Unit").text());
            $("td", row).eq(4).html($(this).find("HeaderName").text());
            $("td", row).eq(5).html($(this).find("Cell").text());
            $("td", row).eq(6).html($(this).find("Instrument").text());
            $("td", row).eq(7).html($(this).find("ShortName").text());
            $("td", row).eq(8).html($(this).find("Int_count").text());
            $("td", row).eq(9).html($(this).find("CellValues").text());
            $("td", row).eq(10).html($(this).find("Int_range").text());
            $("td", row).eq(11).html($(this).find("Runchart").text());
            $("td", row).eq(12).html($(this).find("DID").text());
            $("td", row).eq(13).html($(this).find("DID").text());
            $("[id*=grd_dynmaster]").append(row);
            row = $("[id*=grd_dynmaster] tr:last-child").clone(true);
        });
    }
}

$(function()
{
    $("select[id$='slt_runchart']").change(function()
    {
        var value=$("select[id$='slt_runchart']").val();
        if(value == "Yes")
        {
            $("tr[id$='runperccent']").show();
        }
        else if(value == "No")
        {
            $("tr[id$='runperccent']").hide();
        }
    });
    
});


function valdynDelValues()
{
    if(!valPartNo())return false
    if(!valOperation())return false
    if(!valCell())return false
    if(!valConfirm())return false
}
function valConfirm()
{
    if (confirm("Are you sure you want to delete this event?"))
    {
        return true;
    }
    else
    {
        return false;
    }
}

function valPartNo()
{
    var pname=$("select[id$='dy_del_partno']").val();
    if(pname!="0" && pname!="-Select-")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("select[id$='dy_del_partno']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Select Part Number');
        return false;
    }
}

function valOperation()
{
    var oper=$("select[id$='dy_del_operation']").val();
    if(oper!="0" && oper!="-Select-")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("select[id$='dy_del_operation']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Select Operation');
        return false;
    }
}

function valCell()
{
    var cell=$("select[id$='dy_del_cell']").val();
    if(cell!="0" && cell!="-Select-")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("select[id$='dy_del_cell']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Select Cell');
        return false;
    }
}

function isNumber_noofcell(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if ((charCode == 49) || ((charCode != 50) && (charCode < 58 && charCode > 50)) || ((charCode > 31) && (charCode < 48 || charCode > 57)) ) {
        return false;
    }
    return true;
}
function isNumber_instvalue(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}