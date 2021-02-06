var status="0";

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
var page=$('#hdn_page').val();
 
var bws = getBrowserHeight();
shadow.style.width = bws.width + 'px';
shadow.style.height = bws.height + 'px';
if(page=="1")
{
question.style.left = parseInt((bws.width - 400) / 2)+ 'px';
 question.style.top = parseInt((bws.height - 550) / 2)+ 'px';
}
else
{
 question.style.left = parseInt((bws.width - 400) / 2)+ 'px';
 question.style.top = parseInt((bws.height - 550) / 2)+ 'px';
 }
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

function showerromessage()
{
        var query=$('#hdn_error').val();
        var Error=[];
        Error=query;
        var sp=Error.split(",");
        var tbl="<div><table style='width:100%;'>";
        for(var i=0;i<sp.length;i++)
        {
            if(sp[i]=="," || sp[i]=="")
            {
            }
            else
            {
                tbl+='<tr><td style="text-align:left;"><span style="font-size:12px; color:red; text-align:left;">* '+sp[i]+'</span></td></tr>';
            }
        }
        tbl+="</table></div>";
        $("#div_errro").html(tbl);
        showLayer();
}

function validaterejectionreason()
{
    if(!validatereg())return false
    return true;
}
function validatereg()
{
    var rej= $("#txtcomment").val();
    if(rej==null || rej=="")
    {
         $("#txtcomment") .addClass("errormsg");
         $("#txtcomment").focus()
         return false;
         
    }
    else
    {
        $("#txtcomment") .removeClass("errormsg").addClass( "" );
        return true;
    }

}
function updatecomment(table,id,rowid)
{
var table=$("#hdn_table").val();
var id=$("#hdn_pid").val();
var rowid=$("#hdn_rowid").val();

    var res='';
    var cmd='';
    res=validaterejectionreason();
   
    if(res==true)
    {
    
        cmd= $("#txtcomment").val();
        $.ajax({
                url:"../Master/Default.aspx/updateRejValue",
                data:"{'Table':'"+table+"','PID':'"+id+"','Comment':'"+cmd+"','RowId':'"+rowid+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    var page=$("#hdn_pageurl").val();
                    window.top.location.href=page;
                },
                error:function()
                {}
              });
    }
}

//function ShowRejectCmd_UPdate(table,id,Qid)
//{
//$("#hdn_table").val(table);
//$("#hdn_pid").val(id);
//$("#hdn_Qid").val(Qid);
//    var values='';
//    $.ajax({
//                url:"../Master/Default.aspx/GetRejValue_update",
//                data:"{'Table':'"+table+"','PID':'"+id+"','Q_ID':'"+Qid+"'}",
//                type:"POST",
//                contentType: "application/json; charset=utf-8",
//                dataType: "json",
//                success: function(msg)
//                {
//              
//                    values=msg.d;
//                    $("#hdn_rowid").val(values);
//                    if(values!="F")
//                    {
//                        var tbl="<div><table style='width:100%;'>";
//                        tbl+='<tr><td style="text-align:center;"><span style="font-size:14px; color:black; text-align:left;">Please Enter the Rejection Reason</span></td></tr>';
//                        tbl+='<tr style="height:10px;"><td style="text-align:left;"></td></tr>';
//                        tbl+='<tr><td style="text-align:left;"><div align="center"><input type="text" id="txtcomment" style="width:300px; height:30px;" onkeypress="return Enterkey(this);"/></div></td></tr>';
//                        tbl+='<tr style="height:10px;"><td style="text-align:left;"></td></tr>';
//                        tbl+='<tr><td style="text-align:left;cursor:pointer;"><div align="center"><img src="../Menu_image/Submit.jpg" id="img_submit" onclick="javascript:updatecomment();"/></div></td></tr>';
//                        tbl+='<tr style="height:10px;"><td style="text-align:left;"></td></tr>';
//                        tbl+="</table></div>";
//                         $("input[id$='txtcomment']").focus();
//                        $("#div_errro").html(tbl);
//                       
//                        //$("#txtcomment").focus();
//                        showLayer();
//                        $("#div_close").hide();
//                    }
//                    else
//                    {
//                        alert('Data Submitted Successfuly !');
//                    }
//                },
//                error:function()
//                {}
//              });
//    
//}


//function showfixture()
//{


//var color='';
//var fixno='';
//var from ='';
//var to='';
//var partno='';
//   $.ajax({

//                url:"../Master/Default.aspx/GetfixtureValue",
//                data:"{}",
//                type:"POST",
//                contentType: "application/json; charset=utf-8",
//                dataType: "json",
//                success: function(msg)
//                {
//                //
//                    if(msg.d!="" && msg.d!=null)
//                    {
//                        for(var i=0;i<msg.d.length;i++)
//                        {
//                        
//                                    fixno=msg.d[i].fixname;
//                                    partno=msg.d[i].partno1;
//                                    if(msg.d[i].fixname!=null && msg.d[i].fixname!="")
//                                    {
//                                        $('#hdn_fixno').val(msg.d[i].fixname);
//                                        if(parseInt(msg.d[i].partno)>0)
//                                        {
//                                           
//                                                $('#div_fixture').show();
//                                                $('#spn_fixno').text(msg.d[i].fixname);
//                                                $('#spn_fixtot').text(msg.d[i].partno);
//                                            if(parseInt(msg.d[i].partno)>=parseInt(msg.d[i].gf) && parseInt(msg.d[i].partno)<= parseInt(msg.d[i].gt))
//                                            {
//                                                $('#spn_fixduration').text('( '+Math.round(msg.d[i].gf)+' TO  '+Math.round(msg.d[i].gt)+' )');
//                                                $('#div_fixture').css('background-color', 'green');
//                                                color='Green';
//                                                from =msg.d[i].gf;
//                                                to=msg.d[i].gt;
//                                               showfixturepop(partno,fixno,color,from,to);
//                                            }
//                                            if(parseInt(msg.d[i].partno)>=parseInt(msg.d[i].yf) && parseInt(msg.d[i].partno)<=parseInt(msg.d[i].yt))
//                                            {
//                                                $('#spn_fixduration').text('( '+Math.round(msg.d[i].yf)+' TO  '+Math.round(msg.d[i].yt)+' )');
//                                                $('#div_fixture').css('background-color', 'orange');
//                                                color='Yellow';
//                                                from =msg.d[i].yf;
//                                                to=msg.d[i].yt;
//                                                showfixturepop(partno,fixno,color,from,to,"","");
//                                            }
//                                            if(parseInt(msg.d[i].partno)>=parseInt(msg.d[i].rf) && parseInt(msg.d[i].partno)<=parseInt(msg.d[i].rt))
//                                            {
//                                                $('#spn_fixduration').text('( '+Math.round(msg.d[i].rf)+' TO  '+Math.round(msg.d[i].rt)+' )');
//                                                $('#div_fixture').css('background-color', 'red');
//                                                color='Red';
//                                                from =msg.d[i].rf;
//                                                to=msg.d[i].rt;
//                                               showfixturepop(partno,fixno,color,from,to,msg.d[i].partno,msg.d[i].rt);
//                                            }
//                                            
//                                         }
//                                         else{
//                                         $('#div_fixture').hide();
//                                         }
//                                    }
//                                    else
//                                    {
//                                        var modal = document.getElementById('myModal1');
//                                        modal.style.display = "block";
//                                         $('#spn_msg1').text('Fixture Name Not Allocated for');
//                                         $('#spn_parthome1').text(msg.d[i].partno1 +'');
//                                    }
//                            
//                        }
//                        
//                    }
//                    else
//                    {
//                    alert('');
//                    }
//                },
//                error:function()
//                {}
//              });
//              
//}

function showfixture()
{

var color='';
var fixno='';
var from ='';
var to='';
var partno='';
var tbl='';
var h='';
$.ajax({
        url:"../Master/Default.aspx/GetfixtureValue",
        data:"{}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            if(msg.d!="" && msg.d!=null)
            {
                h=55;
                tbl +="<div id='div_fixscroll' style='height:100px;'>";
                for(var i=0;i<msg.d.length;i++)
                {
                     fixno=msg.d[i].fixname;
                     partno=msg.d[i].partno1;
                    if(msg.d[i].fixname!=null && msg.d[i].fixname!="")
                    {
                        if(parseInt(msg.d[i].partno)>0)
                        {
                            
//                                tbl +="<div style='margin-left: -80px; margin-top: 0px; text-align: right;' align='center'><div style='padding-right: 60px;'> <span style='font-family: Arial; font-size: 30px; font-weight: bold; color: #fff;'>";
//                                $('#div_fixture').show();
//                                tbl+=msg.d[i].fixname+"</span></div><br />";
//                                tbl+="<div style='padding-right: 90px;'><span style='font-family: Arial; font-size: 30px; font-weight: bold; color: #fff;'>";
//                                $('#hdn_fixno').val(msg.d[i].multifixname);
                            if(parseInt(msg.d[i].partno)>=parseInt(msg.d[i].gf) && parseInt(msg.d[i].partno)<= parseInt(msg.d[i].gt))
                            {
                             //$('#spn_fixduration').text('( '+Math.round(msg.d[i].gf)+' TO  '+Math.round(msg.d[i].gt)+' )');
                                if(i==0)
                                {tbl +="<div style='margin-left: -80px; margin-top: -30px; text-align: right;' align='center'><div style='padding-right: 60px;'> <span style='font-family: Arial; font-size: 30px; font-weight: bold; color: green;'>";}
                                else{
                                tbl +="<div style='margin-left: -80px; margin-top: 0px; text-align: right;' align='center'><div style='padding-right: 60px;'> <span style='font-family: Arial; font-size: 30px; font-weight: bold; color: green;'>";
                                }
                                $('#div_fixture').show();
                                tbl+=msg.d[i].fixname+"</span></div>";
                                tbl+="<div style='padding-right: 90px;'><span style='font-family: Arial; font-size: 30px; font-weight: bold; color: green;'>";
                                $('#hdn_fixno').val(msg.d[i].multifixname);
                                tbl +="( "+Math.round(msg.d[i].gf)+" TO  "+Math.round(msg.d[i].gt)+" ) </span></div>";
                                tbl +="<div align='center'><span style='font-family: Arial; font-size: 40px; font-weight: bold; color: green;'>"+msg.d[i].partno + "</span></div></div>";        

//                                $('#div_fixture').css('background-color', 'green');
                                color='Green';
                                from =msg.d[i].gf;
                                to=msg.d[i].gt;
                                showfixturepop(partno,fixno,color,from,to);
                            }
                            if(parseInt(msg.d[i].partno)>=parseInt(msg.d[i].yf) && parseInt(msg.d[i].partno)<=parseInt(msg.d[i].yt))
                            {
                            //$('#spn_fixduration').text('( '+Math.round(msg.d[i].yf)+' TO  '+Math.round(msg.d[i].yt)+' )');
                                if(i==0)
                                {tbl +="<div style='margin-left: -80px; margin-top: -20px; text-align: right;' align='center'><div style='padding-right: 60px;'> <span style='font-family: Arial; font-size: 30px; font-weight: bold; color: orange;'>";}
                                else{
                                tbl +="<div style='margin-left: -80px; margin-top: 0px; text-align: right;' align='center'><div style='padding-right: 60px;'> <span style='font-family: Arial; font-size: 30px; font-weight: bold; color: orange;'>";
                                }
                                $('#div_fixture').show();
                                tbl+=msg.d[i].fixname+"</span></div>";
                                tbl+="<div style='padding-right: 90px;'><span style='font-family: Arial; font-size: 30px; font-weight: bold; color: orange;'>";
                                $('#hdn_fixno').val(msg.d[i].multifixname);
                                tbl +="( "+Math.round(msg.d[i].yf)+' TO  '+Math.round(msg.d[i].yt)+" ) </span></div>";
                                tbl +="<div align='center'><span style='font-family: Arial; font-size: 40px; font-weight: bold; color: orange;'>"+msg.d[i].partno + "</span></div></div>";        

//                                $('#div_fixture').css('background-color', 'orange');
                                color='Yellow';
                                from =msg.d[i].yf;
                                to=msg.d[i].yt;
                                showfixturepop(partno,fixno,color,from,to,"","");
                            }
                            if(parseInt(msg.d[i].partno)>=parseInt(msg.d[i].rf) && parseInt(msg.d[i].partno)<=parseInt(msg.d[i].rt))
                            {
                            //$('#spn_fixduration').text('( '+Math.round(msg.d[i].rf)+' TO  '+Math.round(msg.d[i].rt)+' )');
                            if(i==0)
                            {tbl +="<div style='margin-left: -80px; margin-top: -20px; text-align: right;' align='center'><div style='padding-right: 60px;'> <span style='font-family: Arial; font-size: 30px; font-weight: bold; color: red;'>"; }
                            else
                            {
                                tbl +="<div style='margin-left: -80px; margin-top: 0px; text-align: right;' align='center'><div style='padding-right: 60px;'> <span style='font-family: Arial; font-size: 30px; font-weight: bold; color: red;'>";
                            }
                                $('#div_fixture').show();
                                tbl+=msg.d[i].fixname+"</span></div>";
                                tbl+="<div style='padding-right: 90px;'><span style='font-family: Arial; font-size: 30px; font-weight: bold; color: red;'>";
                                $('#hdn_fixno').val(msg.d[i].multifixname);
                                tbl +="( "+Math.round(msg.d[i].rf)+' TO  '+Math.round(msg.d[i].rt)+" ) </span></div>";
                                tbl +="<div align='center'><span style='font-family: Arial; font-size: 40px; font-weight: bold; color: red;'>"+msg.d[i].partno + "</span></div></div>";        

//                                $('#div_fixture').css('background-color', 'red');
                                color='Red';
                                from =msg.d[i].rf;
                                to=msg.d[i].rt;
                                showfixturepop(partno,fixno,color,from,to,msg.d[i].partno,msg.d[i].rt);
                            }
                            else
                            {
                                if(parseInt(msg.d[i].partno)>=parseInt(msg.d[i].rt))
                                {
                                    tbl +="<div style='margin-left: -80px; margin-top: 0px; text-align: right;' align='center'><div style='padding-right: 60px;'> <span style='font-family: Arial; font-size: 30px; font-weight: bold; color: red;'>";
                                    $('#div_fixture').show();
                                    tbl+=msg.d[i].fixname+"</span></div><br />";
                                    tbl+="<div style='padding-right: 90px;'><span style='font-family: Arial; font-size: 30px; font-weight: bold; color: red;'>";
                                    $('#hdn_fixno').val(msg.d[i].multifixname);
                                    tbl +="( "+Math.round(msg.d[i].rf)+' TO  '+Math.round(msg.d[i].rt)+" ) </span></div><br />";
                                    tbl +="<div align='center'><span style='font-family: Arial; font-size: 50px; font-weight: bold; color: red;'>"+msg.d[i].partno + "</span></div></div>";        

    //                                $('#div_fixture').css('background-color', 'red');
                                    color='Red';
                                    from =msg.d[i].rf;
                                    to=msg.d[i].rt;
                                    showfixturepop(partno,fixno,color,from,to,msg.d[i].partno,msg.d[i].rt);
                                }
                            }   
//                         tbl +="<div align='center'><span style='font-family: Arial; font-size: 50px; font-weight: bold; color: #fff;'>"+msg.d[i].partno + "</span></div></div>";        
                          if(i > 3)
                          {
                            h +=30;
                            jQuery('.chat').css({"height": + h +"%"});
                          }
                        }
                        else{
                            $('#div_fixture').hide();
                        }
                    }
                    else
                    {
                        var modal = document.getElementById('myModal1');
                        modal.style.display = "block";
                        $('#spn_msg1').text('Fixture Name Not Allocated for');
                        $('#spn_parthome1').text(msg.d[i].partno1 +'');
                    }
                    
                }
                tbl +="</div>";
                $("#div_fixSheetValues").html(tbl); 
            }
            else
            {
                var modal = document.getElementById('myModal1');
                modal.style.display = "block";
                $('#spn_msg1').text('Fixture Name Not Allocated');
                 //$('#spn_parthome1').text(msg.d[i].partno1 +'');
            }
        },
        error:function()
        {}
   });
}



function ShowRejectCmd(table,id,Qid)
{
$("#hdn_table").val(table);
$("#hdn_pid").val(id);
//$("#hdn_Qid").val(Qid);
    var values='';
    $.ajax({
                url:"../Master/Default.aspx/GetRejValue",
                data:"{'Table':'"+table+"','PID':'"+id+"','Q_ID':'"+Qid+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    values=msg.d;
                    $("#hdn_rowid").val(values);
                    if(values!="F")
                    {
                        var tbl="<div><table style='width:100%;'>";
                        tbl+='<tr><td style="text-align:center;"><span style="font-size:14px; color:black; text-align:left;">Please Enter the Rejection Reason</span></td></tr>';
                        tbl+='<tr style="height:10px;"><td style="text-align:left;"></td></tr>';
                        tbl+='<tr><td style="text-align:left;"><div align="center"><input type="text" id="txtcomment" style="width:300px; height:30px;" onkeypress="return Enterkey(this);"/></div></td></tr>';
                        tbl+='<tr style="height:10px;"><td style="text-align:left;"></td></tr>';
                        tbl+='<tr><td style="text-align:left;cursor:pointer;"><div align="center"><img src="../Menu_image/Submit.jpg" id="img_submit" onclick="javascript:updatecomment();"/></div></td></tr>';
                        tbl+='<tr style="height:10px;"><td style="text-align:left;"></td></tr>';
                        tbl+="</table></div>";
                        $("input[id$='txtcomment']").focus();
                        $("#div_errro").html(tbl);
                        //$("#txtcomment").focus();
                        showLayer();
                        $("#div_close").hide();
                    }
                    else
                    {
                        alert('Data Submitted Successfuly !');
                    }
                },
                error:function()
                {}
              });
    
}


function ShowRejectCmdNew(table,id,Qid)
{
$("#hdn_table").val(table);
$("#hdn_pid").val(id);
//$("#hdn_Qid").val(Qid);
    var values='';
    $.ajax({
                url:"../Master/Default.aspx/GetRejValueNew",
                data:"{'Table':'"+table+"','PID':'"+id+"','Q_ID':'"+Qid+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    values=msg.d;
                    $("#hdn_rowid").val(values);
                    if(values!="F")
                    {
                        var tbl="<div><table style='width:100%;'>";
                        tbl+='<tr><td style="text-align:center;"><span style="font-size:14px; color:black; text-align:left;">Please Enter the Rejection Reason</span></td></tr>';
                        tbl+='<tr style="height:10px;"><td style="text-align:left;"></td></tr>';
                        tbl+='<tr><td style="text-align:left;"><div align="center"><input type="text" id="txtcomment" style="width:300px; height:30px;" onkeypress="return Enterkey(this);"/></div></td></tr>';
                        tbl+='<tr style="height:10px;"><td style="text-align:left;"></td></tr>';
                        tbl+='<tr><td style="text-align:left;cursor:pointer;"><div align="center"><img src="../Menu_image/Submit.jpg" id="img_submit" onclick="javascript:updatecomment();"/></div></td></tr>';
                        tbl+='<tr style="height:10px;"><td style="text-align:left;"></td></tr>';
                        tbl+="</table></div>";
                        $("input[id$='txtcomment']").focus();
                        $("#div_errro").html(tbl);
                        //$("#txtcomment").focus();
                        showLayer();
                        $("#div_close").hide();
                    }
                    else
                    {
                        alert('Data Submitted Successfuly !');
                    }
                },
                error:function()
                {}
              });
    
}
function showerromessage2(message)
{
       
        var Error=[];
        Error=message;
        var sp=Error.split(",");
        var tbl="<div><table style='width:100%;'>";
        for(var i=0;i<sp.length;i++)
        {
            if(sp[i]=="," || sp[i]=="")
            {
            }
            else
            {
                tbl+='<tr><td style="text-align:left;"><span style="font-size:14px; color:red; text-align:left;font-family:arial;">* '+sp[i]+'</span></td></tr>';
            }
        }
        tbl+="</table></div>";
        $("#div_errro").html(tbl);
        showLayer();
}
function showcyclemessage(part,operation)
{
        var partno=part;
        var tbl="<div><table style='width:100%;'>";
        tbl+='<tr><td style="text-align:left;"><span style="font-size:16px; color:red; text-align:left;">* Please Enter Cycle Time for '+partno+'('+operation+')</span></td></tr>';
        tbl+="</table></div>";
        $("#div_errro").html(tbl);
        $("#div_close").hide();
        showLayer();
}
function showerromessage1(message)
{

if(message!="" && message!=null)
{

    var query=message;
        var Error=[];
        Error=query;
        var sp=Error.split(",");
   
        var tbl="<div><table style='width:100%;'>";
        for(var i=0;i<sp.length;i++)
        {
      
            if(sp[i]=="," || sp[i]=="")
            {
            }
            else
            {
                tbl+='<tr><td style="text-align:left;"><span style="font-size:12px; color:red; text-align:left;">* '+sp[i]+'</span></td></tr>';
            }
        }
        tbl+="</table></div>";
       
        $("#div_errro").html(tbl);
        showLayer();
}
        
}
$(function()
{
 $('#div_close').click(function()
 {
   hideLayer();
 });
});
function validate_userpage()
{
if(!validate_partno())return false
if(!validate_process())return false
if(!validate_type())return false
}
function validate_partno()
{
    var partno=$("select[id$='DropPart']").val();
    if(partno=="-Select-" || partno==null)
    {
        $("select[id$='DropPart']").focus();
        alert("Select Part No");
        return false;
    }
    else
    {
        return true;
    }
    
}
function validate_process()
{
    var process=$("input[id$='hdn_process']").val();
  
     if(process==null || process=="")
    {
   
        $("select[id$='DropProcess']").focus();
        alert("Select Process");
        return false;
    }
    else
    {
        return true;
    }

}
function validate_type()
{   
     var type=$("select[id$='DropType']").val();
    if(type=="0" || type==null)
    {
        $("select[id$='DropType']").focus();
        alert("Select Type");
        return false;
    }
    else
    {
        return true;
    }
    
}

function checkvalues()
{
    if(!validate_partno())return false
    if(!validate_type())return false
}

function validate_regpid()
{
     var pid=$("input[id$='txt_pidno']").val();
     if(pid=="" || pid==null)
     {
        $("input[id$='txt_pidno']").addClass( "errormsg" );
        return false;
    }
    else
    {
        $("input[id$='txt_pidno']").removeClass( "errormsg" );
        return true;
    }
}
function getregvalues(data)
{
 $("input[id$='hdn_regid']").val(data);
     $.ajax({
                url:"../Master/Default.aspx/GetRegValues",
                data:"{'ID':'"+data+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    for(var i=0;i<msg.d.length;i++)
                    {
                         $("div[id$='div_save']").hide();
                         $("div[id$='div_update']").show();
                         $("span[id$='spnpassword']").text('Old Password');
                         $("span[id$='spn_repassword']").text('New Password');
                         $("input[id$='txt_username']").val(msg.d[i].UserName);
                         $("input[id$='txt_password']").val(msg.d[i].Password);
                         $("input[id$='txt_password']").attr('disabled','disabled');
                         $("input[id$='txt_retype']").hide();
                         $("input[id$='txtretype']").show();
                         if(msg.d[i].Role=="Super Admin")
                         {
                             $("select[id$='ddl_role']").val('1');
                         }
                         if(msg.d[i].Role=="Admin")
                         {
                             $("select[id$='ddl_role']").val('2');
                         }
                         if(msg.d[i].Role=="User")
                         {
                             $("select[id$='ddl_role']").val('3');
                         }
                         
                         
                         
                    }
                },
                error:function()
                {}
              });
}
function validate_updateregistration()
{
if(!validate_Uusername())return false
if(!validate_Upassword())return false
if(!validate_Uretype())return false
if(!validate_Urole())return false
}
function validate_Uusername()
{
    var useraname=$("input[id$='txt_username']").val();
    if(useraname=="" || useraname==null)
    {
        $("input[id$='txt_username']").addClass( "errormsg" );
        $("input[id$='txt_username']").focus();
        return false;
    }
    else
    {
    $("input[id$='txt_username']").removeClass( "errormsg" );
        return true;
    }
}
function validate_Upassword()
{
    var pass=$("input[id$='txt_password']").val();
    if(pass=="" || pass==null)
    {
        $("input[id$='txt_password']").addClass( "errormsg" );
        $("input[id$='txt_password']").focus();
        return false;
    }
    else
    {
        if(pass.length >=6)
        {
            $("input[id$='txt_password']").removeClass( "errormsg" );
            $("span[id$='sp_error']").hide();
            return true;
        }
        else
        {
           $("span[id$='sp_error']").text('Password Length Should be above 6');
           $("input[id$='txt_password']").focus();
           $("span[id$='sp_error']").show();
            return false;
        }
    }
}
function validate_Uretype()
{
    var repass=$("input[id$='txtretype']").val();
    if(repass=="" || repass==null)
    {
        $("input[id$='txtretype']").addClass( "errormsg" );
        return false;
    }
    else
    {
        if(repass.length >=6)
        {
              $("input[id$='txtretype']").removeClass( "errormsg" );
              $("span[id$='spnretype']").hide();
              return true;
         }
          
        else
        {
           $("span[id$='spnretype']").text('Password Length Should be above 6');
           $("input[id$='spnretype']").addClass( "errormsg" );
           $("input[id$='txtretype']").focus();
           $("span[id$='spnretype']").show();
            return false;
        }
    }
}
function validate_Urole()
{
    var role=$("select[id$='ddl_role']").val();
    if(role=="0" || role==null)
    {
        $("select[id$='ddl_role']").addClass( "errormsg" );
        $("select[id$='ddl_role']").focus();
        return false;
    }
    else
    {
    $("select[id$='ddl_role']").removeClass( "errormsg" );
        return true;
    }
}
function deletevalues(data)
{
    var con=window.confirm('Are You Sure Want To Delete This Registered Details');
    if(con==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/Deleteregister",
                data:"{'ID':'"+data+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        alert("Record Deleted Successfully");
                        window.top.location.href="../WorkInstruction/RegisrationFrm.aspx";
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
//function getgono(event)
//{
//        var key = window.event.keyCode;
//      
//         if((key>=65 && key<=90)||(key>=97 && key<=122))
//        {
//        $('#hdn_numeric').val('1');
//        }
////        else if((key>=48 && key<=57)&& (key>=65 && key<=90)||(key>=97 && key<=122))
////        {
////             $('#hdn_numeric').val('2');
////        }
//        else 
//        {
//            $('#hdn_numeric').val('0');
//        }
//      
//}

//function getgono1(event)
//{
//  
//        var key = window.event.keyCode;
//       
//        if(key>=48 && key<=57)
//        {
//             $('#hdn_numeric1').val('0');
//        }
//        else
//        {
//            $('#hdn_numeric1').val('1');
//        }
//      
//}
//function Enterkeycmt(evt) {
//    var e = event || evt; // for trans-browser compatibility
//    var charCode = e.which || e.keyCode;
//   
//    if (charCode==13)
//    updatecomment();
//        //return false;
//    return true;
//}

function Enterkey(evt) {
    var e = event || evt; // for trans-browser compatibility
    var charCode = e.which || e.keyCode;
   
    if (charCode==13)
        return false;
    return true;
}

function Freqvalue()
{
      var freq=$("input[id$='txtshtf']").val();
    $.ajax({
                url:"../Master/Default.aspx/checkFreqvalue",
                data:"{'Freq':'"+freq+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        alert("Already Exist Freq.Value..!!");
                        $("input[id$='txtshtf']").val('');
                         $("input[id$='txtshtf']").focus();
                    }
                    else
                    {
                    }
                },
                error:function()
                {}
              });
    
   
}
$(document).ready(function()
{
var pidno =$("input[id$='PID']").val();
var admpidno=$("select[id$='drp_pidno']").val();
var tblname =$("input[id$='gettableName']").val();
    $.ajax({
                url:"../Master/Default.aspx/GetQtyRej",
                data:"{'TableName':'"+tblname+"','Pidno':'"+pidno+"','Admpidno':'"+admpidno+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                 $('#REJECTED').text(msg.d);
                },
                error:function()
                {}
              });

 });


$(function()
{
    $('#div_open').click(function ()
    {
             $("#div_fixture").animate({right: '260px'});
             $('#div_open').hide();
             $('#div_clos').show();
    });
 });
 $(function()
{
    $('#div_clos').click(function ()
    {
             $("#div_fixture").animate({right: '0px'});
             $('#div_open').show();
             $('#div_clos').hide();
    });
 });

function showfixturepop(partno,fixno,color,from,to,Rcount,Tcount)
{

    $.ajax({
                url:"../Master/Default.aspx/GetFixtureStatus",
                data:"{'Color':'"+color+"','FixtureNo':'"+fixno+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
               
                    if(msg.d!="" && msg.d!=null && msg.d!="F")
                    {
//                        $('#hdn_color').val(msg.d);
                        if(msg.d=="G")
                        {
//                             $('#div_fixtureerror').css('background-color', 'green');
//                             $('#div_model').css('background-color', 'green');
//                             $('#spn_message').text('Fixture within life period');
//                             $('#spn_message').css('color', 'white');
//                             $('#spn_sterror').css('color', 'red');
//                             $('#spn_username').css('color', 'white');
//                             $('#spn_password').css('color', 'white');
//                             $('#spn_exist').css('color', 'white');
//                             $('#spn_new').css('color', 'white');
//                             $('#spn_or').css('color', 'white');
//                             $('#div_or').show();
//                             $('#div_cancel').show();
//                             $('#spnuser').css('color', 'white');
//                             $('#spnpass').css('color', 'white');
//                             $('#spn_head').text(fixno+ '   (  '+ partno +'  )');
//                        modalPosition();
//                        $(window).resize(function () {
//                            modalPosition();
//                        });
//                       // $('.openModal').click(function (e) {
//                            $('.modal, .modal-backdrop').fadeIn('fast');
//                         //   e.preventDefault();
//                        //});
                             
                        }
                        if(msg.d=="Y")
                        {
//                             $('#div_fixtureerror').css('background-color', 'yellow');
//                             $('#div_model').css('background-color', 'yellow');
//                             $('#spn_message').text('Fixture life reaches Service zone (' +from+ ' TO ' +to+ ')');
//                             $('#spn_message').css('color', 'black');
//                             $('#spn_sterror').css('color', 'red');
//                             $('#spn_username').css('color', 'black');
//                             $('#spn_password').css('color', 'black');
//                             $('#spn_exist').css('color', 'black');
//                             $('#spn_new').css('color', 'black');
//                             $('#spn_or').css('color', 'black');
//                             $('#div_or').show();
//                             $('#div_cancel').show();
//                             $('#spnuser').css('color', 'black');
//                             $('#spnpass').css('color', 'black');
//                             $('#spn_head').text(fixno+ '   (  '+ partno +'  )');
//                             modalPosition();
//                             $(window).resize(function () {
//                                    modalPosition();
//                             });
//                               // $('.openModal').click(function (e) {
//                             $('.modal, .modal-backdrop').fadeIn('fast');
//                                   // e.preventDefault();
//                                //});
                        }
                        if(msg.d=="R")
                        {
                             $('#div_fixtureerror').css('background-color', 'red');
                             $('#div_model').css('background-color', 'red');
                             $('#spn_message').text('Fixture life completed(>' +Tcount+ ') Data should not able to enter');
                             $('#spn_message').css('color', 'white');
                             $('#spn_sterror').css('color', 'white');
                             $('#spn_username').css('color', 'white');
                             $('#spn_password').css('color', 'white');
                             $('#spn_logerror').css('color', 'white');
                             $('#spn_exist').css('color', 'white');
                             $('#spn_new').css('color', 'white');
                             $('#div_or').hide();
                             $('#div_cancel').hide();
                             $('#div_fixsubmit').hide();
                             if(parseInt(Rcount)>=parseInt(Tcount))
                             {
                                $('#hdn_color').val(msg.d);
                                $('#hdn_fixno').val(fixno);
                                $('#spn_head').text(fixno+ '   (  '+ partno +'  )');
                                modalPosition();
                                $(window).resize(function () {
                                    modalPosition();
                                });
                               // $('.openModal').click(function (e) {
                                $('.modal, .modal-backdrop').fadeIn('fast');
                                   // e.preventDefault();
                                //});
                             }
                        }
                       
                       
                    }
                 
                },
                error:function()
                {}
              });

}
function modalPosition() {
getBrowserHeight();
var shadow = document.getElementById('divmodel');
var bws = getBrowserHeight();
shadow.style.width = bws.width+1000 + 'px';
shadow.style.height = bws.height+1000 + 'px';
    var width = $('.modal').width();
    var pageWidth = $(window).width();
    var x = (pageWidth / 2) - (width / 2);
    $('.modal').css({ left: x + "px" });
}

$(function()
{
    $('#btn_status').click(function()
    {
       $('#div_btnstatus').hide();
       $('#div_remarks').fadeIn('fast');
       $('#spn_message').text('Enter Remarks');
       // $('.modal, .modal-backdrop').fadeOut('fast');
    });
});
$(function()
{
    $('#btn_savestatus').click(function()
    {
    var res=checkstatus();
   
        if(res==true)
        {
                $('#div_fixtureerror1').hide();
                $('#div_remarks').hide();
                $('#div_log').show();
                
        }
    });
});
function checkstatus()
{
    if(!validate_status())return false
    return true;
}
function validate_status()
{
    var s=$('#Txt_remarks').val();
    if(s=="" || s==null)
    {
        $('#div_staterror').show();
        $('#spn_sterror').text('Please Enter the Remark');
        $('#Txt_remarks').focus();
        return false;
    }
    else
    {
        $('#div_staterror').hide();
        return true;
    }
    
}
$(function()
{
    $('#btn_login').click(function()
    {
    
        var res=checklog();
        if(res==true)
        {   
                var fix='';
                var pwrd=$('#txtpassword').val();
                var username=$('#txtusername').val();
                var machine=$('#txt_machinename').val();
                 if ($("#rdo_exist:checked").length == 1)
                 {
                    fix="E";
                 }
                 if($("#rdo_new:checked").length == 1)
                 {
                    fix="N";
                 }
                $.ajax({
                url:"../Master/Default.aspx/checkuser_shift",
                data:"{'Username':'"+username+"','Password':'"+pwrd+"'}",
                type:"POST",
                contentType:"application/json; charset=utf-8",
                dataType:"json",
                success: function(msg)
                {
                    if(msg.d=="Super Admin")
                    {
                  
                        var color=$('#hdn_color').val();
                        var status=$('#Txt_remarks').val();
                        var fixtureno=$('#hdn_fixno').val();
                        var id='';
                        $.ajax({
                            url:"../Master/Default.aspx/savefixturestatus",
                            data:"{'Color':'"+color+"','Status':'"+status+"','Fix':'"+fix+"','FixtureNo':'"+fixtureno+"'}",
                            type:"POST",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function(msg)
                            {
                           
                           // var name = $.session.get('Operation');
                          //  id=msg.d[0].res;
                             id=msg.d;
                          // var op='';
                          
                                $('#hdn_vid').val(id);
                                if(id=="S")
                                {
                                     $('.modal, .modal-backdrop').fadeOut('fast');
                                   
                                  var op=$('#hdn_operation').val();
                                     if($('#hdn_process').val()=="OP1")
                                     {
                                        op="1";
                                     }
                                     if($('#hdn_process').val()=="OP2")
                                     {
                                        op="2";
                                     }
                                     showfixture($('#hdn_partno').val(),op,$('#hdn_table1').val());
                                     return;
                                }
                                 if(id!="F" && id!=null)
                                {
                                     $('.modal, .modal-backdrop').fadeOut('fast');
                                     $.ajax({
                                        url:"../Master/Default.aspx/editfixvalues",
                                        data:"{'ID':'"+id+"'}",
                                        type:"POST",
                                        contentType: "application/json; charset=utf-8",
                                        dataType: "json",
                                        success: function(msg)
                                        {
                                            if(msg.d!="" && msg.d!=null)
                                            {
                                                for(var i=0;i<msg.d.length;i++)
                                                {
                                                    $("#txt_partno").val(msg.d[i].partno);
                                                    $("#fix_no").val(msg.d[i].fixname);
                                                    $("#txt_operation").val(msg.d[i].operation);
                                                    $("#txtfixlife").val(msg.d[i].life);
                                                    $("#txt_grom").val(msg.d[i].gf);
                                                    $("#txt_gto").val(msg.d[i].gt);
                                                    $("#txt_yfrom").val(msg.d[i].yf);
                                                    $("#txt_yto").val(msg.d[i].yt);
                                                    $("#txt_rfrom").val(msg.d[i].rf);
                                                    $("#txt_rto").val(msg.d[i].rt);
                                                }
                                                showLayer1();
                                            }
                                            else
                                            {
                                            }
                                        },
                                        error:function()
                                        {}
                                      }); 
                                     
                                }
                            },
                            error:function()
                            {}
                          });
                    }
                    else{
                            $('#spn_logerror').text('You are not a Admin to update Remarks');
                            $('#div_logerror').show();
                                 $('#txtpassword').val('');
                                 $('#txtusername').val('');
                                 $('#txtusername').focus();
                    }
                },
                error:function(error)
                {}
              });
                
                
        }
        else
        {
        }
    });
});
function checklog()
{
   // if(!validaetfixno())return false
    if(!validateusername1())return false
    if(!validatepassword1())return false
    return true;
}
function validaetfixno()
{
    if (($("#rdo_exist:checked").length == 0) && ($("#rdo_new:checked").length == 0))
    {
        $('#div_logerror').show();
        $('#spn_logerror').text('Select Fixture No Options');
        return false;
    }
    else
    {
        $('#div_logerror').hide();
        return true;
    }
}

function validateusername1()
{
    var username=$('#txtusername').val();
  
    if(username=="" || username ==null)
    {
       // $('#txt_username').focus();
        $('#div_logerror').show();
        $('#spn_logerror').text('Enter User Name');
        return false;
    }
    else
    {   
        $('#div_logerror').hide();
        return true;
    }
    
}
function validatepassword1()
{
     var pwrd=$('#txtpassword').val();
     var username=$('#txtusername').val();
    if(pwrd=="" || pwrd ==null)
    {
//       $('#txtPassword').focus();
      $('#div_logerror').show();
        $('#spn_logerror').text('Enter Password');
        return false;
    }
    else
    {
        $('#div_logerror').hide();
        return true;
    }
}
$(function()
{
    $('#btn_cancel').click(function()
    {
        $('#div_btnstatus').hide();
        $('#div_fixtureerror1').hide();
        $('#div_ignore').fadeIn('fast');
        
    });
});
function checkignore()
{
////
    if(!validateusername11())return false
    if(!validatepassword11())return false
    return true;
}
function validateusername11()
{
////
    var username=$('#txtusername1').val();
  
    if(username=="" || username ==null)
    {
       // $('#txt_username').focus();
        $('#div_logerror1').show();
        $('#spn_logerror1').text('Enter User Name');
        return false;
    }
    else
    {   
        $('#div_logerror1').hide();
        return true;
    }
    
}
function validatepassword11()
{
////
     var pwrd=$('#txtPassword1').val();
    if(pwrd=="" || pwrd ==null)
    {
//       $('#txtPassword').focus();
      $('#div_logerror1').show();
        $('#spn_logerror1').text('Enter Password');
        return false;
    }
    else
    {
        $('#div_logerror1').hide();
        return true;
    }
}
$(function()
{
   $('#btn_ignore').click(function()
   {
    saveignore();
   }); 
});
function saveignore()
{
////
    var res=checkignore();
        if(res==true)
        {   
                var username=$('#txtusername1').val();
                var pwrd=$('#txtPassword1').val();
                var color=$('#hdn_color').val();
                $.ajax({
                url:"../Master/Default.aspx/Ignorefixture",
                data:"{'Username':'"+username+"','Password':'"+pwrd+"','Color':'"+color+"'}",
                type:"POST",
                contentType:"application/json; charset=utf-8",
                dataType:"json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                         $('.modal, .modal-backdrop').fadeOut('fast');
                    }
                    else{
                    }
                },
                error:function(error)
                {}
              });
                
                
        }
        else
        {
        }
}







function setLayerPosition1() {
var shadow = document.getElementById('shadow1');
var question = document.getElementById('question1');
 
var bws = getBrowserHeight();
shadow.style.width = bws.width + 'px';
shadow.style.height = bws.height + 'px';
 question.style.left = parseInt((bws.width - 900) / 2)+ 'px';
 question.style.top = parseInt((bws.height - 550) / 2)+ 'px';
shadow = null;
question = null;
}

 
function showLayer1() {
setLayerPosition1();
var shadow = document.getElementById('shadow1');
var question = document.getElementById('question1');
// var popdiv = document.getElementById('popdiv');
shadow.style.display = 'block';
question.style.display = 'block';
 
shadow = null;
question = null;
}
 
function hideLayer1() {
var shadow = document.getElementById('shadow1');
var question = document.getElementById('question1');
 
shadow.style.display = 'none';
question.style.display = 'none';
 
shadow = null;
question = null;
}

function vallife()
{
    if(!v_life1())return false
    return true;
}
function v_life1()
{
    var life=$('#txt_morelife').val();
  
    if(life=="" || life ==null)
    {
        $('#diverror').show();
        $('#spn_error').text('Enter More Life');
        return false;
    }
    else
    {   
        $('#diverror').hide();
        return true;
    }
}
$(function()
{
   $('#brn_fixvalues').click(function()
   {
    var res=vallife();
  
    if(res==true)
    {
        savevalues ($('#hdn_vid').val());
    }
   });
});

function savevalues(id)
{
//
            var greenfrom='';
            var greento='';
            var yellowfrom='';
            var yellowto='';
            var redfrom='';
            var redto='';
            var fixturename = $("#hdn_fixno").val();
            var life=$("#txtfixlife").val();
            var life1=$("#txt_morelife").val();
            var gf=$("#txt_grom").val();
            var gt=$("#txt_gto").val();
            var yf=$("#txt_yfrom").val();
            var yt=$("#txt_yto").val();
            var rf=$("#txt_rfrom").val();
            var rt=$("#txt_rto").val();
            var newlife=parseInt(life)+parseInt(life1);
            greenfrom=(parseInt(newlife)*parseInt(gf))/100;
            greento=(parseInt(newlife)*parseInt(gt))/100;
            yellowfrom=(parseInt(newlife)*parseInt(yf))/100;
            yellowto=(parseInt(newlife)*parseInt(yt))/100;
            redfrom=(parseInt(newlife)*parseInt(rf))/100;
            redto=(parseInt(newlife)*parseInt(rt))/100;
            
            $.ajax({
                url:"../Master/Default.aspx/savefixvalues1",
                data:"{'ID':'"+id+"','Life':'"+life+"','Gf':'"+gf+"','Gt':'"+gt+"','Yf':'"+yf+"','Yt':'"+yt+"','Rf':'"+rf+"','Rt':'"+rt+"','Life1':'"+life1+"','GrFrom':'"+Math.round(greenfrom)+"','Grto':'"+Math.round(greento)+"','YEfrom':'"+Math.round(yellowfrom)+"','Yeto':'"+Math.round(yellowto)+"','Refrom':'"+Math.round(redfrom)+"','Reto':'"+Math.round(redto)+"','Fixturename':'"+fixturename+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
               
                    if(msg.d=="S")
                    {
                    showfixture();
                       hideLayer1();
                    }
                    else{
                    }
                    
                },
                error:function()
                {}
              });
}




$(function()
{
    $('#div_cellright').click(function ()
    {
         $("#div_cellstatus").animate({left: '0px'});
         $('#div_cellright').hide();
         $('#div_cellleft').show();
    });
 });
 $(function()
{
    $('#div_cellleft').click(function ()
    {
         $("#div_cellstatus").animate({left: '365px'});
         $('#div_cellright').show();
         $('#div_cellleft').hide();
    });
 });


$(function()
{
    $('#div_fopen').click(function ()
    {
             $("#divfeedback").animate({left: '0px'});
             $('#div_fopen').hide();
             $('#div_fclos').show();
    });
 });
 $(function()
{
    $('#div_fclos').click(function ()
    {
             $("#divfeedback").animate({left: '560px'});
             $('#div_fopen').show();
             $('#div_fclos').hide();
    });
 });
 
 $(function()
 {
    $('#btn_feedback').click(function()
    {
        var res=checkfeedback();
        if(res==true)
        {
            var feedback=$("#txt_feedback").val();
            var mach=$('#txt_machinename').val();
            $.ajax({
                url:"../Master/Default.aspx/SaveFB",
                data:"{'FeedBack':'"+feedback+"','Machine':'"+mach+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
               
                    if(msg.d=="N")
                    {
                       var url="../Home.aspx";
                       window.top.location.href=url;
                       
                    }
                    else{
                               if(msg.d=="S")
                               {
                                    $("#divfeedback").animate({left: '0px'});
                                    $('#div_fopen').hide();
                                    $('#div_fclos').show();
                                    $("#txt_feedback").val('');
                                    $('#spn_count').text('');
                               }
                               else
                               {
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
 
 function checkfeedback()
 {
 if(!val_feedback())return false
 return true;
 }
 function val_feedback()
 {
       var fb=$('#txt_feedback').val();
      
        if(fb=="" || fb ==null)
        {
            alert('Please Enter Your FeedBack');
            return false;
        }
        else
        {   
            return true;
        }
 }
 
 
$(function()
{
    $('#txt_feedback').keypress(function()
    {
         var fb=$('#txt_feedback').val();
         $('#spn_count').text(parseInt(fb.length));
    });
});

function valdate()
{
    if(!valfromdate())return false
    if(!valtodate())return false
    return true;
}
function valfromdate()
{
     var from =$("input[id$='txt_fromdate']").val();
     if(from!="")
     {
        return true;
        
     }
     else{
        alert('Please Select the From date');
        return false;
     }
}
function valtodate()
{
     var to =$("input[id$='txt_todate']").val();
     if(to!="")
     {
        return true;
        
     }
     else{
        alert('Please Select the To date');
        return false;
     }
}
//$(function ()
//{
//    $('#btn_fixfeedbacksearch').click(function()
//    {
function showfeedback_view()
{
    
         var res=valdate();
          var from =$("input[id$='txt_fromdate']").val();
          var to =$("input[id$='txt_todate']").val();
         if(res==true)
         {
var tbl = '<div><table style="border-top:solid 1px #000;border-left:solid 1px #000;" cellspacing="0" width="100%"><tr style="background-color:#105fe0;height:35px;"><td class="tdclass" style="border-left:solid 1px #fff;width:50px;"><span class="classspan"><span>S.No</span></td><td class="tdclass" style="width:100px;"><span class="classspan">Opr Name</span></td><td class="tdclass" style="width:100px;"><span class="classspan">Part Number</span></td><td class="tdclass" style="width:100px;"><span class="classspan">Operation</span></td><td class="tdclass" style="width:100px;"><span class="classspan">Cell</span></td><td class="tdclass" style="width:100px;"><span class="classspan">Shift</span></td><td class="tdclass" style="width:100px;"><span class="classspan">Machine</span></td><td class="tdclass" style="width:300px;"><span class="classspan">FeedBack</span></td><td class="tdclass" style="width:100px;"><span class="classspan">Date</span></td><td class="tdclass" style="width:200px;"><span class="classspan">Response</span></td><td class="tdclass" style="width:100px;border-right:solid 1px #000;"><span class="classspan">Date</span></td></tr>';
     $.ajax({
                url:"../Master/Default.aspx/GetFB_view",
                data:"{'Fromdate':'"+from+"','Todate':'"+to+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                
                        if(msg!=null && msg!="")
                        {
                            var count=0;
                            var response='';
                            for(var i=0;i<msg.d.length;i++)
                            {
                               count+=1;
                               if(msg.d[i].response=="" && msg.d[i].r_date=="")
                               {
                                 response='<a style="cursor:pointer;color:blue;text-decoration: underline;" id='+msg.d[i].id+' onclick="javascript:response(this.id);"><span class="spn">Response</span></a>';
                                
                               }
                               else
                               {
                                response=msg.d[i].response;
                               }
                               tbl+='<tr><td class="tdclass1"><span class="spn">'+count+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].name+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].partno+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].operation+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].cell+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].shift+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].machine+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].feedback+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].fdate+'</span></td><td class="tdclass1"><span class="spn">'+response+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].r_date+'</span></td></tr>'; 
                            }
                            tbl+='</table></div>';
                            $("div[id$='divfeedback']").html(tbl);
                        }
                        else
                        {
                            tbl+='</table></div>';
                            $("div[id$='divfeedback']").html(tbl);
                        }
                         $("div[id$='divfeedback']").show();  
                },
                error:function()
                {}
              });

          } 
}  
//    });
//});
function showfeedback()
{

var tbl = '<div><table style="border-top:solid 1px #000;border-left:solid 1px #000;" cellspacing="0" width="100%"><tr style="background-color:#105fe0;height:35px;"><td class="tdclass" style="border-left:solid 1px #fff;width:50px;"><span class="classspan"><span>S.No</span></td><td class="tdclass" style="width:100px;"><span class="classspan">Opr Name</span></td><td class="tdclass" style="width:100px;"><span class="classspan">Part Number</span></td><td class="tdclass" style="width:100px;"><span class="classspan">Operation</span></td><td class="tdclass" style="width:100px;"><span class="classspan">Cell</span></td><td class="tdclass" style="width:100px;"><span class="classspan">Shift</span></td><td class="tdclass" style="width:100px;"><span class="classspan">Machine</span></td><td class="tdclass" style="width:300px;"><span class="classspan">FeedBack</span></td><td class="tdclass" style="width:100px;"><span class="classspan">Date</span></td><td class="tdclass" style="width:200px;"><span class="classspan">Response</span></td><td class="tdclass" style="width:100px;border-right:solid 1px #000;"><span class="classspan">Date</span></td></tr>';
     $.ajax({
                url:"../Master/Default.aspx/GetFB",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                        if(msg!=null && msg!="")
                        {
                            var count=0;
                            var response='';
                            for(var i=0;i<msg.d.length;i++)
                            {
                               count+=1;
                               if(msg.d[i].response=="" && msg.d[i].r_date=="")
                               {
                                 response='<a style="cursor:pointer;color:blue;text-decoration: underline;" id='+msg.d[i].id+' onclick="javascript:response(this.id);"><span class="spn">Response</span></a>';
                                
                               }
                               else
                               {
                                response=msg.d[i].response;
                               }
                               tbl+='<tr><td class="tdclass1"><span class="spn">'+count+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].name+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].partno+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].operation+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].cell+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].shift+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].machine+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].feedback+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].fdate+'</span></td><td class="tdclass1"><span class="spn">'+response+'</span></td><td class="tdclass1"><span class="spn">'+msg.d[i].r_date+'</span></td></tr>'; 
                            }
                            tbl+='</table></div>';
                            $("div[id$='divfeedback']").html(tbl);
                        }
                        else
                        {
                            tbl+='</table></div>';
                            $("div[id$='divfeedback']").html(tbl);
                        }
                },
                error:function()
                {}
              });


}
function response(id)
{
    $("input[id$='hdn_fbid']").val(id);
    showLayer();  
}
$(function ()
{
    $('#btn_submit').click(function()
    {
         var res=checkfb1();
         if(res==true)
         {
            var id=$("input[id$='hdn_fbid']").val();
           var msg=$("textarea[id$='txt_response']").val();
            $.ajax({
                url:"../Master/Default.aspx/saveResponse",
                data:"{'ID':'"+id+"','Message':'"+msg+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        showfeedback();
                        hideLayer();
                    }
                    if(msg.d=="N")
                    {
                       var url="../Home.aspx";
                       window.top.location.href=url;
                    }
                },
                error:function()
                {}
              });
         }   
    });
});
function checkfb1()
{
    if(!v_fb())return false
    return true;
}
function v_fb()
 {
       var fb=$("textarea[id$='txt_response']").val();
        if(fb=="" || fb ==null)
        {
            alert('Please Enter Your Response');
            return false;
        }
        else
        {   
            return true;
        }
 }
 
 $(function()
 {
    $('#link_one').click(function()
    {
       one();
    });
 });
  $(function()
 {
    $('#link_two').click(function()
    {
          two();
           showfeedback();
    });
 });
 function one()
 {  
    $("div[id$='view1']").show();   
    $("div[id$='view2']").hide();   
     
 }
  function two()
 {
   
    $("div[id$='view1']").hide();   
    $("div[id$='view2']").show();   
 }
 
 
 
 
 
 
 
 function check_feedback()
 {
    if(!v_partno())return false
    if(!v_fixno())return false
    if(!v_operation())return false
    if(!v_machine())return false
    if(!v_year())return false
    if(!v_month1())return false
    if(!v_month2())return false
    return true;
 }
 function v_partno()
 {
       var part=$("select[id$='ddl_fpartno']").val();
        if(part=="0")
        {
            $('#div_fcaerror').show();
            $('#spn_ferror').text('Select Part No');
            return false;
        }
        else
        {   
             $('#div_fcaerror').hide();
              $("input[id$='hdn_fpart']").val(part);
            return true;
        }
 }
 function v_fixno()
 {
       var fix=$("select[id$='ddl_ffixno']").val();
        if(fix=="0")
        {
            $('#div_fcaerror').show();
            $('#spn_ferror').text('Select Fix No');
            return false;
        }
        else
        {   
             $('#div_fcaerror').hide();
             $("input[id$='hdn_ffixno']").val(fix);
            return true;
        }
 }
 function v_operation()
 {
       var ope=$("select[id$='ddl_foperation']").val();
        if(ope=="0")
        {
            $('#div_fcaerror').show();
            $('#spn_ferror').text('Select Operation');
            return false;
        }
        else
        {   
             $('#div_fcaerror').hide();
             $("input[id$='hdn_foperation']").val(ope);
            return true;
        }
 }
 function v_machine()
{
    var mach= $("select[id$='ddl_fmachine']").val();
    
    if(mach =="0")
    {
        $('#div_fcaerror').show();
        $('#spn_ferror').text('Select Machine');
         $("select[id$='ddl_fmachine']").focus();
        return false;
    }
    else
    {
          $('#div_fcaerror').hide();
          $("input[id$='hdn_fmachi']").val(mach);
        return true;
    }
}
function v_year()
{
    var year= $("select[id$='ddl_fyear']").val();
     
    if(year =="0" || year=="--- Select Year ---")
    {
        $('#div_fcaerror').show();
        $('#spn_ferror').text('Select Machine');
         $("select[id$='ddl_fyear']").focus();
        return false;
    }
    else
    {
          $('#div_fcaerror').hide();
          $("input[id$='hdn_fyear']").val(year);
        return true;
    }
}
function v_month1()
{
    var month= $("select[id$='ddl_fmonth']").val();
    if(month =="0")
    {
        $('#div_fcaerror').show();
        $('#spn_ferror').text('Select Month');
         $("select[id$='ddl_fmonth']").focus();
        return false;
    }
    else
    {
          $('#div_fcaerror').hide();
           $("input[id$='hfn_fmonth1']").val(month);
        return true;
    }
}
function v_month2()
{
    var month1= $("select[id$='ddl_fmonthto']").val();
    var month2= $("select[id$='ddl_fmonth']").val();
     //$("input[id$='hdn_month']").val(month);
    if(month1 =="0")
    {
        $('#div_fcaerror').show();
        $('#spn_ferror').text('Select Month');
         $("select[id$='ddl_monthto']").focus();
        return false;
    }
    else
    {
        if(parseInt(month2)>parseInt(month1))
        {
             $('#div_fcaerror').show();
             $('#spn_ferror').text('From Month Can not be greater than To date');
               return false;
        }
        else
        {
             $('#div_caerror').hide();
             $("input[id$='hdn_fmonth2']").val(month1);
            return true;
        }
       
    }
}
 function getfixno()
{
    var part=$("select[id$='ddl_fpartno']").val();
    $.ajax({
                url:"../Master/Default.aspx/Get_fixname",
                data:"{'ID':'"+part+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
              
                    $("select[id$='ddl_ffixno']").get(0).options.length = 0;
                    $("select[id$='ddl_ffixno']").get(0).options[0] = new Option("--- Select Fixture No ---", "0");
                   // $("select[id$='ddl_cfixno']").get(0).options[1] = new Option("ALL", "ALL");
                    
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='ddl_ffixno']").get(0).options[$("select[id$='ddl_ffixno']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    
                    part=null;
                    comma=null;
                    
              },
                error:function()
                {}
              });
}
function loadpartno()
{
        $.ajax({
                url:"../Master/Default.aspx/Get_prtno",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
               
                    $("select[id$='ddl_fpartno']").get(0).options.length = 0;
                    $("select[id$='ddl_fpartno']").get(0).options[0] = new Option("--- Select Part Number ---", "0");
                    $("select[id$='ddl_fpartno']").get(0).options[1] = new Option("ALL", "ALL");
                    
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='ddl_fpartno']").get(0).options[$("select[id$='ddl_fpartno']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    part=null;
                    comma=null;
                    getmachine_fix();
              },
                error:function()
                {}
              });
              
}

function getmachine_fix()
{

    $.ajax({
                url:"../Master/Default.aspx/Get_machine_fix",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    $("select[id$='ddl_fmachine']").get(0).options.length = 0;
                    $("select[id$='ddl_fmachine']").get(0).options[0] = new Option("--- Select Machine Name ---", "0");
                    // $("select[id$='ddl_machine']").get(0).options[1] = new Option("ALL", "ALL");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='ddl_fmachine']").get(0).options[$("select[id$='ddl_fmachine']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    
                    part=null;
                    comma=null;
                    GetfixtureProcess();
              },
                error:function()
                {}
              });
}

function GetfixtureProcess()
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
            $("select[id$='ddl_foperation']").get(0).options.length = 0;
            $("select[id$='ddl_foperation']").get(0).options[0] = new Option("--- Select Operation ---", "0");
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
                        $("select[id$='ddl_foperation']").get(0).options[$("select[id$='ddl_foperation']").get(0).options.length] = new Option(comma[count], "1");                            
                    }
                    else if(comma[count]=="OP2")
                    {
                        $("select[id$='ddl_foperation']").get(0).options[$("select[id$='ddl_foperation']").get(0).options.length] = new Option(comma[count], "2");
                    }
                    else
                    {
                        $("select[id$='ddl_foperation']").get(0).options[$("select[id$='ddl_foperation']").get(0).options.length] = new Option(comma[count], comma[count]);
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
function getmachine()
{

    $.ajax({
                url:"../Master/Default.aspx/Get_machine",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    $("select[id$='ddl_fmachine']").get(0).options.length = 0;
                    $("select[id$='ddl_fmachine']").get(0).options[0] = new Option("--- Select Machine Name ---", "0");
                     
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='ddl_fmachine']").get(0).options[$("select[id$='ddl_fmachine']").get(0).options.length] = new Option(comma[count], comma[count]);
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
    $('#ch_breakdown').click(function()
    {
            var name=$('#spn_machinename').text();
            if($('#ch_breakdown').attr('checked')) {
            $('#ch_running').attr('checked', false);
            $('#ch_stop').attr('checked', false);
            updatembustatus(name,'BreakDown');
             
            }
     
    });
});
$(function()
{
    $('#ch_running').click(function()
    {
            var name=$('#spn_machinename').text();
            if($('#ch_running').attr('checked')) {
            $('#ch_breakdown').attr('checked', false);
            $('#ch_stop').attr('checked', false);
             updatembustatus(name,'Running');
        }
     
    });
});

$(function()
{
    $('#ch_stop').click(function()
        {       
                var name=$('#spn_machinename').text();
                if($('#ch_stop').attr('checked')) {
                $('#ch_breakdown').attr('checked', false);
                $('#ch_running').attr('checked', false);
                updatembustatus(name,'Stopped');
          }
     
    });
});
function updatembustatus(machine,status)
{
 $.ajax({
                url:"../Master/Default.aspx/Updatembustatus",
                data:"{'Machine':'"+machine+"','Status':'"+status+"','Cell':'Valve','Unit':'MBU'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                         $("#div_cellstatus").animate({left: '0px'});
                        $('#div_cellright').hide();
                        $('#div_cellleft').show();
                        showmachinestatus();
                    }
                },
                error:function()
                {}
              });
}
function  showmachinestatus()
{
   var name=$('#spn_machinename').text();
    $.ajax({
                url:"../Master/Default.aspx/SelectmbuStatus",
                data:"{'Unit':'MBU','Cell':'Valve','Name':'"+name+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                //////
                    if(msg.d=="" || msg.d=="Running")
                    {
                         $('#ch_breakdown').attr('checked',false);
                         $('#ch_running').attr('checked', true);
                         $('#ch_stop').attr('checked', false);
                    }
                    if(msg.d=="BreakDown")
                    {
                        $('#ch_breakdown').attr('checked',true);
                         $('#ch_running').attr('checked', false);
                         $('#ch_stop').attr('checked', false);
                    }
                     if(msg.d=="Stopped")
                    {
                        $('#ch_breakdown').attr('checked',false);
                         $('#ch_running').attr('checked', false);
                         $('#ch_stop').attr('checked', true);
                    }
                   // showabucellstatus1();
                },
                error:function()
                {}
              });
}