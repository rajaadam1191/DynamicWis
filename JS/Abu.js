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

 question.style.left = parseInt((bws.width - 1000) / 2)+ 'px';
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


function validateabu()
{
    if(!val_tno())return false
    if(!val_aval())return false
    if(!val_station())return false
    if(!val_desc())return false
   // if(val_photo())return false
    if(!val_rten())return false
    if(!val_issue())return false
    if(!val_qty())return false
    if(!val_maint())return false
    
    
}
function val_tno()
{
    var tno=$("select[id$='txt_toolnumber']").val();
    if(tno!="0")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {   
        $("select[id$='txt_toolnumber']").focus();
        $('#diverror').show();
        $('#spn_error').text('Select the Tool Number');
        return false;
    }
}
function val_aval()
{
    var avail=$("select[id$='ddl_availability']").val();
    if(avail!="0")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {   
        $("select[id$='ddl_availability']").focus();
        $('#diverror').show();
        $('#spn_error').text('Select The Availability');
        return false;
    }
}
function val_station()
{
    var station=$("input[id$='txt_mstation']").val();
    if(station!="0")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_mstation']").focus();
        $('#diverror').show();
        $('#spn_error').text('Enter The Station');
        return false;
    }
}
function val_desc()
{
    var desc=$("input[id$='txt_description']").val();
    if(desc!="")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_description']").focus();
        $('#diverror').show();
        $('#spn_error').text('Enter The Description');
        return false;
    }
}
function val_photo()
{
    var photo=$("input[id$='up_photo']").val();
    if(photo!="")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {   
        $("input[id$='up_photo']").focus();
        $('#diverror').show();
        $('#spn_error').text('Upload Tools Image');
        return false;
    }
}
function val_rten()
{
    var retn=$("input[id$='txt_retension']").val();
    if(retn!="")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_retension']").focus();
        $('#diverror').show();
        $('#spn_error').text('Enter Retension Time');
        return false;
    }
}
function val_issue()
{
    var issue=$("input[id$='txt_issuedon']").val();
    if(issue!="")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_issuedon']").focus();
        $('#diverror').show();
        $('#spn_error').text('Select Issued Date');
        return false;
    }
}
function val_qty()
{
    var qty=$("input[id$='txt_quantity']").val();
    if(qty!="")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_quantity']").focus();
        $('#diverror').show();
        $('#spn_error').text('Enter Station Quantity');
        return false;
    }
}
function val_maint()
{
    var maint=$("input[id$='txt_maintained']").val();
    if(maint!="")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_maintained']").focus();
        $('#diverror').show();
        $('#spn_error').text('Enter Spare Maintain values');
        return false;
    }
}

function datachk()
{
//    $("input[id$='txt_issuedon']").blur(function()
//   {
   var cont=$("input[id$='txt_retension']").val();
   var d=$("input[id$='txt_issuedon']").val();

   $.ajax({
                url:"../Master/Default.aspx/add_days",
                data:"{'Date':'"+d+"','Count':'"+cont+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!=null && msg.d!="")
                    {
                       $("input[id$='txt_dueon']").val(msg.d);
                    }
                },
                error:function()
                {}
              });
//   });
}

//$(function()
//{

//    $("input[id$='txt_issuedon']").blur(function()
//   {
//   var cont=$("input[id$='txt_retension']").val();
//   var d=$("input[id$='txt_issuedon']").val();
//   alert(d);
//    alert(cont);
//   $.ajax({
//                url:"../Master/Default.aspx/add_days",
//                data:"{'Date':'"+d+"','Count':'"+cont+"'}",
//                type:"POST",
//                contentType: "application/json; charset=utf-8",
//                dataType: "json",
//                success: function(msg)
//                {
//                    if(msg.d!=null && msg.d!="")
//                    {
//                       $("input[id$='txt_dueon']").val(msg.d);
//                    }
//                },
//                error:function()
//                {}
//              });
//   });
//});
$(function()
{
    $("input[id$='txt_retension']").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode == 65 && ( e.ctrlKey === true || e.metaKey === true ) ) || 
            (e.keyCode >= 35 && e.keyCode <= 40)) {
                 return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });
});
function deletemaster(id)
{
     var res=window.confirm('Are You Sure Want to delete this record ?');
     if(res==true)
     {
     $.ajax({
                url:"../Master/Default.aspx/DeleteAbuMaster",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        var url="../ABU/AbuMaster.aspx";
                        window.top.location.href=url;
                    }
                },
                error:function()
                {}
              });
     }
     else{
     }
}

function loadtoolnum(id)
{
     $.ajax({
        url:"../ABU/AbuMaster.aspx/BindToolNumberEdit",
        data:"{'toolid':'"+id+"'}",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(data)
        {
//        ////
//            var txt_toolnumber = $("[id*=txt_toolnumber]");
//            txt_toolnumber.empty();
//            $.each(r.d, function () {
//                txt_toolnumber.append($("<option></option>").val(this['Value']).html(this['Text']));
//            });
            var txt_toolnumber = $("[id*=txt_toolnumber]");
            txt_toolnumber.empty().append('<option  value="0">--- Select Tool Number ---</option>');
            $.each(data.d, function(key, value) {
            txt_toolnumber.append($("<option selected='selected'></option>").val(value.ID).html(value.ToolNumber));
            });

        },
        error:function()
        {}
      });
}
function editmaster(id)
{
 $("input[id$='hdn_id']").val(id);
 $("div[id$='div_save']").hide();
 $("div[id$='div_update']").show();
  $("div[id$='div_life_extended']").show();
     $.ajax({
                url:"../Master/Default.aspx/EditAbuMaster",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!=null)
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
                            loadtoolnum(msg.d[i].tno);
                            $("select[id$='txt_toolnumber']").val(msg.d[i].tno);
                            $("select[id$='ddl_availability']").val(msg.d[i].davail);
                            $("input[id$='txt_mstation']").val(msg.d[i].station);
                            $("input[id$='txt_description']").val(msg.d[i].desc);
                            $("input[id$='txt_retension']").val(msg.d[i].rtime);
                            $("input[id$='txt_issuedon']").val(msg.d[i].issued);
                            $("input[id$='txt_quantity']").val(msg.d[i].qty);
                            $("input[id$='txt_maintained']").val(msg.d[i].maint);
                            $("input[id$='txt_dueon']").val(msg.d[i].next);
                            $("select[id$='txt_replaced']").val(msg.d[i].replaced);
                            $("input[id$='txt_extended']").val(msg.d[i].extended);
                            $("input[id$='txt_rectified']").val(msg.d[i].rectified);
                            $("input[id$='txt_others']").val(msg.d[i].other);
                            $("input[id$='txt_premature']").val(msg.d[i].premature);
                            $("input[id$='hdn_issued']").val(msg.d[i].issued);
                            $("input[id$='hdn_sparecount']").val(msg.d[i].maint);
                        }
                    }
                },
                error:function()
                {}
              });
}


function fnZoomImage(imageUrl) {
     var imgDiv = document.getElementById("divImage");
     var imgZoom = document.getElementById("imgZoom");
     imgZoom.src = imageUrl.replace("Thumbnail", "Full");
     var width = document.body.clientWidth;
     imgDiv.style.left = (width - 500) / 2 + "px";
     imgDiv.style.display = "block";
     imgZoom.style.display = "block";
     return false;
 }
function HideImage() {
     var imgDiv = document.getElementById("divImage");
     var imgZoom = document.getElementById("imgZoom");
     imgDiv.style.display = "none";
     imgZoom.style.display = "none";
 }

function edittool(id)
{
    $("input[id$='hdn_toolid']").val(id);
    $("div[id$='div_toolsave']").hide();
    $("div[id$='div_toolupdate']").show();
   
     $.ajax({
                url:"../Master/Default.aspx/EditAbutoolMaster",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!=null)
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
                            $("input[id$='txt_toolno']").val(msg.d[i].tno);
                            $("input[id$='txt_tredension']").val(msg.d[i].Retension);
                            $("input[id$='txt_gfrom']").val(msg.d[i].grom);
                            $("input[id$='txt_gto']").val(msg.d[i].gto);
                            $("input[id$='txt_yfrom']").val(msg.d[i].yfrom);
                            $("input[id$='txt_yto']").val(msg.d[i].yto);
                            $("input[id$='txt_rfrom']").val(msg.d[i].rfrom);
                            $("input[id$='txt_rto']").val(msg.d[i].rto);
                            $("select[id$='ddl_unit']").val(msg.d[i].unit);
                            $("select[id$='ddl_tooltype']").val(msg.d[i].type);
                            $("select[id$='ddl_line']").val(msg.d[i].line);
                        }
                    }
                },
                error:function()
                {}
              });
}

function validateabutool()
{
    if(!valunit())return false
    if(!valtype())return false
    if(!valline())return false
    if(!valtollno())return false
    if(!valtreden())return false
    if(!valgf())return false
    if(!valgt())return false
    if(!valyf())return false
    if(!valyt())return false
    if(!valrf())return false
    if(!valrt())return false
}
function valunit()
{
    var unt=$("select[id$='ddl_unit']").val();
    if(unt!="0")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("select[id$='ddl_unit']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Select Unit');
        return false;
    }
}
function valtype()
{
    var type=$("select[id$='ddl_tooltype']").val();
    if(type!="0")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("select[id$='ddl_tooltype']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Select Tool Type');
        return false;
    }
}
function valline()
{
    var line=$("select[id$='ddl_line']").val();
    if(line!="0")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("select[id$='ddl_line']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Select Line/ Machine');
        return false;
    }
}
function valtollno()
{
    var tno=$("input[id$='txt_toolno']").val();
    if(tno!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_toolno']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the Tool Number');
        return false;
    }
}
function valtreden()
{
    var red=$("input[id$='txt_tredension']").val();
    if(red!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_tredension']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the Retension Time');
        return false;
    }
}
function valgf()
{
    var gf=$("input[id$='txt_gfrom']").val();
    if(gf!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_gfrom']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the green from range');
        return false;
    }
}
function valgt()
{
    var gt=$("input[id$='txt_gto']").val();
    if(gt!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_gto']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the green to range');
        return false;
    }
}
function valyf()
{
    var yf=$("input[id$='txt_yfrom']").val();
    if(yf!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_yfrom']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the Yellow from range');
        return false;
    }
}
function valyt()
{
    var yt=$("input[id$='txt_yto']").val();
    if(yt!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_yto']").focus();
        $('#diverror').show();
        $('#spn_error').text('Enter the Yellow to range');
        return false;
    }
}
function valrf()
{
    var rf=$("input[id$='txt_rfrom']").val();
    if(rf!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_rfrom']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the Red from range');
        return false;
    }
}
function valrt()
{
    var rt=$("input[id$='txt_rto']").val();
    if(rt!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_rto']").focus();
        $('#diverror1').show();
        $('#spn_error1').text('Enter the Red to range');
        return false;
    }
}
function validateabu1()
{
    if(!val_tno())return false
    if(!val_aval())return false
    if(!val_station())return false
    if(!val_desc())return false
   // if(val_photo())return false
    if(!val_rten())return false
    if(!val_issue())return false
    if(!val_qty())return false
    if(!val_maint())return false
    
    //if(!val_newspared())return false
    
    //if(!val_extend())return false
    //if(!val_rectified())return false
    //if(!val_other())return false
    //if(!val_premature())return false
    
    var spare=$("select[id$='ddl_replaced']").val();
    if(spare =="No")
    {
     if(!val_extend())return false
    }
    else
    {
    }
    
}
function val_newspared()
{
    var spare=$("select[id$='ddl_replaced']").val();
    if(spare!="0")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {   
        $("select[id$='ddl_replaced']").focus();
        $('#diverror').show();
        $('#spn_error').text('Select the New Spared Replacd');
        return false;
    }
}
function val_extend()
{
    var extend=$("input[id$='txt_extended']").val();
    if(extend!="" && extend!="0")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_extended']").focus();
        $('#diverror').show();
        $('#spn_error').text('Enter the Life Extended');
        return false;
    }
}
function val_rectified()
{
    var rect=$("input[id$='txt_rectified']").val();
    if(rect!="")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_rectified']").focus();
        $('#diverror').show();
        $('#spn_error').text('Enter the Tool Rectified');
        return false;
    }
}
function val_other()
{
    var other=$("input[id$='txt_others']").val();
    if(other!="")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_others']").focus();
        $('#diverror').show();
        $('#spn_error').text('Enter the Other Data');
        return false;
    }
}
function val_premature()
{
    var prem=$("input[id$='txt_premature']").val();
    if(prem!="")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {   
        $("input[id$='txt_premature']").focus();
        $('#diverror').show();
        $('#spn_error').text('Enter the Tool Premature Failure');
        return false;
    }
}

function Feedback(id)
{
    $("input[id$='hdn_toid']").val(id);
    showLayer();
    
}
$(function()
{
    $("select[id$='ddl_replaced']").change(function()
    {
        var val=$("select[id$='ddl_replaced']").val();

        if(val=='Yes')
        {
         $.ajax({
                url:"../Master/Default.aspx/Changedate",
                data:"{'Replaced':'"+val+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                   $("input[id$='txt_issuedon']").val(msg.d);
                   var sp=$("input[id$='txt_maintained']").val();
                   $("input[id$='hdn_sparecount']").val(sp);
                   var spare=parseInt(sp)-parseInt(1);
                   if(spare >=0)
                   {
                       $("input[id$='txt_maintained']").val(spare);
                       $("input[id$='hdn_sparecount1']").val(spare);
                       $("input[id$='txt_extended']").val('');
                   }
                   else
                   {
                        alert('No Spare for Replace');
                   }
                },
                error:function()
                {}
              });
        }
        else
        {
             $("input[id$='txt_issuedon']").val($("input[id$='hdn_issued']").val());
             $("input[id$='txt_maintained']").val($("input[id$='hdn_sparecount']").val());
             $("input[id$='hdn_sparecount1']").val($("input[id$='hdn_sparecount']").val());
        }
        
    });
    
});

function response(id)
{
        showLayer();
         var tbl="<div><table style='width:100%;'><tr style='background-color:#105fe0;height:35px;'><td style='text-align:center; color:#fff;width:150px;'><span>Tool No</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Availability</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Station</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Spare</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Photo</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Drawing</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Retension Time</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Issued On</span></td><td style='text-align:center; color:#fff;width:150px;'><span>Next Due</span></td></tr>";
         $.ajax({
                url:"../Master/Default.aspx/gettoolsvalues",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                  if(msg.d!=null && msg.d!="")
                  {
                   for(var i=0;i<msg.d.length;i++)
                    {
//                         tbl+='<tr><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><span>'+msg.d[i].toolno+'</span></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><span>'+msg.d[i].avail+'</span></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><span>'+msg.d[i].station+'</span></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><span>'+msg.d[i].spare+'</span></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><img src="../ABU/Tools/'+msg.d[i].photo+'" style="width:100px; height:100px;" onmouseover="fnZoomImage(this.src);"/></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><img src="../ABU/Drawing/'+msg.d[i].drawing+'" style="width:100px; height:100px;" onmouseover="fnZoomImage(this.src);"/></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><span>'+msg.d[i].retenstion+'</span></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><span>'+msg.d[i].issued+'</span></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><span>'+msg.d[i].nextdue+'</span></td></tr>';
                        tbl+='<tr><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><span>'+msg.d[i].toolno+'</span></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><span>'+msg.d[i].avail+'</span></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><span>'+msg.d[i].station+'</span></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><span>'+msg.d[i].spare+'</span></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><img src="../ABU/Tools/'+msg.d[i].photo+'" style="width:100px; height:100px;" onmouseover="fnZoomImage(this.src);"/></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><a href="../ABU/Drawing/'+msg.d[i].drawing+'" >'+msg.d[i].drawing+'</a></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><span>'+msg.d[i].retenstion+'</span></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><span>'+msg.d[i].issued+'</span></td><td style="text-align:center; color:#000;width:150px;border:solid 1px #000;"><span>'+msg.d[i].nextdue+'</span></td></tr>';
                    }
        
                        tbl+="</table></div>";
                        $("div[id$='div_toolvalues']").html(tbl);
                  }
                  else{
                  }
                   
                },
                error:function()
                {}
              });
     $("input[id$='hdn_fid']").val(id);
}


function valranges()
{
    if(!valtoolno())return false
    if(!valrfb())return false
}
function valtoolno()
{
    var no=$('#txt_rtoolnumber').val();
    if(no!="0" && no!=null && no!="")
    {
         $('#diverror').hide();
        return true;
    }
    else
    {
        $('#txt_rtoolnumber').focus();
        $('#diverror').show();
        $('#spn_error').text('Select Tool Number');
        return false;
    }
}
function valrfb()
{
    var fb=$('#txt_rfeedback').val();
    if(fb!="")
    {
         $('#diverror').hide();
        return true;
    }
    else
    {
          $('#txt_rtoolnumber').focus();
        $('#diverror').show();
        $('#spn_error').text('Enter FeedBack');
        return false;
    }
}
$(function()
{
    $('#txt_rtoolnumber').change(function()
    {
        var number=$('#txt_rtoolnumber').val();
         $.ajax({
                url:"../Master/Default.aspx/getfeedbacktool",
                data:"{'ID':'"+number+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!=null)
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
                            $("#txt_rstation").val(msg.d[i].station);
                            $("#txt_rretension").val(msg.d[i].rtime);
                            $("#txt_rissuedon").val(msg.d[i].issued);
                            $("#txt_rdueon").val(msg.d[i].next);
                        }
                    }
                },
                error:function()
                {}
              });
    });
});
function valdate()
{
    if(!valfromdate())return false
    if(!valtodate())return false
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
function valunitmaster()
{
    if(!valmasterunit())return false
}
function valmasterunit()
{
    var unit=$("input[id$='txt_unitname']").val();   
    if(unit!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {
        $('#diverror1').show();
        $('#spn_error1').text('Enter The Unit Name');
        return false;
    }
}
function edit_master(id)
{
$("div[id$='div_toolupdate']").show();  
$("div[id$='div_toolsave']").hide();      
         $("input[id$='hdn_masterid']").val(id);  
         $.ajax({
                url:"../Master/Default.aspx/editunitmaster",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!=null)
                    {
                            $("input[id$='txt_unitname']").val(msg.d);   
                    }
                },
                error:function()
                {}
              }); 
}
function edit_mastermbu(id)
{
$("div[id$='div_toolupdate']").show();  
$("div[id$='div_toolsave']").hide();      
         $("input[id$='hdn_masterid']").val(id);  
         $.ajax({
                url:"../Master/Default.aspx/editunitmastermbu",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!=null)
                    {
                            $("input[id$='txt_unitname']").val(msg.d);   
                    }
                },
                error:function()
                {}
              }); 
}
function delete_master(id)
{
    var res=window.confirm('Are You Sure Want To Delete This Assembly Unit');
    if(res==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/deleteunitmaster",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        var url="../ABU/Master.aspx";
                        window.top.location.href=url;
                    }
                },
                error:function()
                {}
              });
    } 
}
function delete_mastermbu(id)
{
    var res=window.confirm('Are You Sure Want To Delete This Assembly Unit');
    if(res==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/deleteunitmastermbu",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                
                    if(msg.d=="S")
                    {
                        var url="../Fixture/UnitMaster.aspx";
                        window.top.location.href=url;
                      //  gridload();
                   }
                },
                error:function()
                {}
              });
    } 
}
function gridload()
{
$.ajax({
                url:"../Fixture/UnitMaster.aspx/loadgrid",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
//                    if(msg.d=="S")
//                    {
//                        var url="../Fixture/UnitMaster.aspx";
//                        window.top.location.href=url;
//                    }
                },
                error:function()
                {}
              });
}
function deletetool(id)
{
    var res=window.confirm('Are You Sure Want To Delete This Tool Master');
    if(res==true)
    {
        $.ajax({
                url:"../ABU/ToolMAster.aspx/deleteToolmaster",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                  
                        var url="../ABU/ToolMAster.aspx";
                        //window.top.location.href=url;
                        window.location.href=url;
                    }
                },
                error:function()
                {}
              });
    } 
}


function edit_TType(id)
{
    $("div[id$='div_toolupdate']").show();  
    $("div[id$='div_toolsave']").hide();      
    $("input[id$='hdn_typeid']").val(id);
    $.ajax({
                url:"../Master/Default.aspx/edittypemaster",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                     if(msg.d!=null)
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
//                             $("input[id$='txt_ttype']").val(msg.d[i].ttext);   
//                            $("input[id$='txt_tvalue']").val(msg.d[i].tvalue);
                            $("input[id$='txt_ttype']").val(msg.d[i].tvalue);   
                            $("input[id$='txt_tvalue']").val(msg.d[i].ttext);     
                        }
                    }
                },
                error:function()
                {}
              }); 
}
function edit_TTypembu(id)
{
    $("div[id$='div_toolupdate']").show();  
    $("div[id$='div_toolsave']").hide();      
    $("input[id$='hdn_typeid']").val(id);
    $.ajax({
                url:"../Master/Default.aspx/edittypemastermbu",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                     if(msg.d!=null)
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
//                             $("input[id$='txt_ttype']").val(msg.d[i].ttext);   
//                            $("input[id$='txt_tvalue']").val(msg.d[i].tvalue);
                            $("input[id$='txt_ttype']").val(msg.d[i].tvalue);   
                            $("input[id$='txt_tvalue']").val(msg.d[i].ttext);     
                        }
                    }
                },
                error:function()
                {}
              }); 
}
function delete_TType(id)
{
    var res=window.confirm('Are You Sure Want To Delete This Tool Type');
    if(res==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/deletetypemaster",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        var url="../ABU/ToolTypeMaster.aspx";
                        window.top.location.href=url;
                    }
                },
                error:function()
                {}
              });
    } 
}
function delete_TTypembu(id)
{
    var res=window.confirm('Are You Sure Want To Delete This Tool Type');
    if(res==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/deletetypemastermbu",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        var url="../Fixture/TypeMaster.aspx";
                        window.top.location.href=url;
                    }
                },
                error:function()
                {}
              });
    } 
}
function valtooltype()
{
    if(!valtoolname())return false
    if(!valtool_type())return false
}
function valtoolname()
{
    var value=$("input[id$='txt_ttype']").val();   
    if(value!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {
        $('#diverror1').show();
        $('#spn_error1').text('Enter The Tool Value');
        return false;
    }
}
function valtool_type()
{
    var name=$("input[id$='txt_tvalue']").val();   
    if(name!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {
        $('#diverror1').show();
        $('#spn_error1').text('Enter The Tool Name');
        return false;
    }
}

function valtooline()
{
    if(!vallinevalue())return false
    if(!vallinename())return false
}
function vallinevalue()
{
    var value=$("input[id$='txt_lvalue']").val();   
    if(value!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {
        $('#diverror1').show();
        $('#spn_error1').text('Enter The Line Value');
        return false;
    }
}
function vallinename()
{
    var name=$("input[id$='txt_lname']").val();   
    if(name!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {
        $('#diverror1').show();
        $('#spn_error1').text('Enter The Line Name');
        return false;
    }
}
function edit_line(id)
{
    $("div[id$='div_toolupdate']").show();  
    $("div[id$='div_toolsave']").hide();      
    $("input[id$='hdn_lineid']").val(id);
    $.ajax({
                url:"../Master/Default.aspx/editlinemaster",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                     if(msg.d!=null)
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
                             $("input[id$='txt_lname']").val(msg.d[i].ttext);   
                            $("input[id$='txt_lvalue']").val(msg.d[i].tvalue);   
                        }
                    }
                },
                error:function()
                {}
              }); 
}
function edit_linembu(id)
{
    $("div[id$='div_toolupdate']").show();  
    $("div[id$='div_toolsave']").hide();      
    $("input[id$='hdn_lineid']").val(id);
    $.ajax({
                url:"../Master/Default.aspx/editlinemastermbu",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                     if(msg.d!=null)
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
                             $("input[id$='txt_lname']").val(msg.d[i].ttext);   
                            $("input[id$='txt_lvalue']").val(msg.d[i].tvalue);   
                        }
                    }
                },
                error:function()
                {}
              }); 
}

function delete_line(id)
{
    var res=window.confirm('Are You Sure Want To Delete This Line Type');
    if(res==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/deletelinemaster",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        var url="../ABU/ToolLineMaster.aspx";
                        window.top.location.href=url;
                    }
                },
                error:function()
                {}
              });
    } 
}
function delete_linembu(id)
{
    var res=window.confirm('Are You Sure Want To Delete This Line Type');
    if(res==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/deletelinemastermbu",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        var url="../Fixture/LineMaster.aspx";
                        window.top.location.href=url;
                    }
                },
                error:function()
                {}
              });
    } 
}
function valsparembu()
{

    //if(!valsparepartno())return false
    if(!valsparenum())return false
    if(!valmax())return false
    if(!valmin())return false
    if(!valcount())return false
}
function valsparepartno()
{
    var part=$("select[id$='ddl_partnumber']").val();   
    if(part!="0")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {
        $('#diverror').show();
        $("select[id$='ddl_partnumber']").focus();
        $('#spn_error').text('Select Part Number');
        return false;
    }
}
function valspare()
{

    if(!valsparenum())return false
    if(!valmax())return false
    if(!valmin())return false
    if(!valcount())return false
}
function valsparenum()
{
    var num=$("select[id$='ddl_toolnumber']").val();   
    if(num!="0")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {
        $('#diverror').show();
        $("select[id$='ddl_toolnumber']").focus();
        $('#spn_error').text('Select Tool Number');
        return false;
    }
}
function valmax()
{
    var max=$("input[id$='txt_maximum']").val();   
    if(max!="")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {
        $('#diverror').show();
        $("input[id$='txt_maximum']").focus();
        $('#spn_error').text('Enter Maximum Spare Value');
        return false;
    }
}
function valmin()
{
    var min=$("input[id$='txt_minimum']").val();   
    if(min!="")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {
        $('#diverror').show();
        $("input[id$='txt_minimum']").focus();
        $('#spn_error').text('Enter Minimum Spare Value');
        return false;
    }
}
function valcount()
{
    var cnt=$("input[id$='txt_sparecount']").val();   
    if(cnt!="")
    {
        $('#diverror').hide();
        return true;
    }
    else
    {
        $('#diverror').show();
        $("input[id$='txt_sparecount']").focus();
        $('#spn_error').text('Enter Spare Count');
        return false;
    }
}
function editsparemaster(id)
{
    $("input[id$='hdn_spareid']").val(id);
    $("div[id$='div_update']").show();  
    $("div[id$='div_save']").hide();      
    $.ajax({
                url:"../Master/Default.aspx/editsparemaster",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                     if(msg.d!=null)
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
                            $("select[id$='ddl_toolnumber']").val(msg.d[i].tool);   
                            $("input[id$='txt_maximum']").val(msg.d[i].max);   
                            $("input[id$='txt_minimum']").val(msg.d[i].min);   
                            $("input[id$='txt_sparecount']").val(msg.d[i].count);   
                        }
                    }
                },
                error:function()
                {}
              }); 
}

function editsparemastermbu(id)
{
    $("input[id$='hdn_spareid']").val(id);
    $("div[id$='div_update']").show();  
    $("div[id$='div_save']").hide();      
    $.ajax({
                url:"../Master/Default.aspx/editsparemastermbu",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!=null)
                    {
                        
                        for(var i=0;i<msg.d.length;i++)
                        {
                            $("select[id$='ddl_partnumber']").val(msg.d[i].partno);
                            $("select[id$='ddl_toolnumber']").val(msg.d[i].tool);   
                            $("input[id$='txt_maximum']").val(msg.d[i].max);   
                            $("input[id$='txt_minimum']").val(msg.d[i].min);   
                            $("input[id$='txt_sparecount']").val(msg.d[i].count);   
                        }
                    }
                },
                error:function()
                {}
              }); 
}
function deletesparemaster(id)
{
    var res=window.confirm('Are You Sure Want To Delete This Spare Master');
    if(res==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/deletesparemaster",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        var url="../ABU/SpareMAster.aspx";
                        window.top.location.href=url;
                    }
                },
                error:function()
                {}
              });
    } 
}
function deletesparemastermbu(id)
{
    var res=window.confirm('Are You Sure Want To Delete This Spare Master');
    if(res==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/deletesparemastermbu",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        var url="../Fixture/SpareMaster.aspx";
                        window.top.location.href=url;
                    }
                },
                error:function()
                {}
              });
    } 
}
function edit_mmaster(id)
{
    $("input[id$='hdn_modelid']").val(id);
    $("div[id$='div_toolupdate']").show();  
    $("div[id$='div_toolsave']").hide();      
    $.ajax({
                url:"../Master/Default.aspx/editmodel",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                     if(msg.d!=null)
                    {
                            $("input[id$='txt_modelname']").val(msg.d);   
                    }
                },
                error:function()
                {}
              }); 
}
function delete_mmaster(id)
{
    var res=window.confirm('Are You Sure Want To Delete This Model');
    if(res==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/deletemodelmaster",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        var url="../Fixture/ModelMaster.aspx";
                        window.top.location.href=url;
                    }
                },
                error:function()
                {}
              });
    } 
}


function Playvideos(id)
{
    $("div[id$='div_abuvideo']").load("../Fixture/PlayVideos.aspx?ID="+id);
    showLayer();
}
function closepop()
{
    hideLayer();
}
function editmail(id)
{
     $("input[id$='hdn_mid']").val(id);
    $("div[id$='div_toolupdate']").show();  
    $("div[id$='div_toolsave']").hide();      
    $.ajax({
                url:"../Master/Default.aspx/editmail1",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                     if(msg.d!=null)
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
                        $("input[id$='txt_musername']").val(msg.d[i].username);
                        $("input[id$='txt_mpassword']").val(msg.d[i].password);
                        $("input[id$='txt_mport']").val(msg.d[i].port);
                        }
                               
                    }
                },
                error:function()
                {}
              }); 
}
function exituser1()
{
    var r=window.confirm('Are You Sure Want To Logout This Page ?');
    if(r==true)
    {
    $.ajax({
                url:"../Master/Default.aspx/logout",
                data:"{}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                     if(msg.d=="S")
                    {
                        var url="../Home.aspx";
                        window.top.location.href=url;
                               
                    }
                },
            
            error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            }
              }); 
    }
    else{
    }
}

function editmailauth(id)
{
     $("input[id$='hdn_midauth']").val(id);
    $("div[id$='div_toolupdate']").show();  
    $("div[id$='div_toolsave']").hide();      
    $.ajax({
                url:"../Master/Default.aspx/editmailauth",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                
                     if(msg.d!=null)
                    {
                     for(var i=0;i<msg.d.length;i++)
                        {
                        $("input[id$='txt_mailaddress']").val(msg.d[i].mailid);
                         $("select[id$='ddl_availability']").val(msg.d[i].unit);
                         }
                               
                    }
                },
                error:function()
                {}
              }); 
}

function deletemailauth(id)
{
    var res=window.confirm('Are You Sure Want To Delete This Mail');
    if(res==true)
    {
        $.ajax({
                url:"../Master/Default.aspx/deleteauth",
                data:"{'ID':'"+id+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d=="S")
                    {
                        var url="../ABU/MailAddress.aspx";
                        window.top.location.href=url;
                    }
                },
                error:function()
                {}
              });
    } 
}
function valmailaddress()
{
    if(!val_mailaddress())return false
}
function val_mailaddress()
{
    var num=$("input[id$='txt_mailaddress']").val();   
    if(num!="")
    {
        $('#diverror1').hide();
        return true;
    }
    else
    {
        $('#diverror1').show();
        $("input[id$='txt_mailaddress']").focus();
        $('#spn_error1').text('Please Enter the Mail Address');
        return false;
    }
}
function printpage(divid)
{
    var prtContent = document.getElementById(divid);
   var WinPrint =
    window.open('','','letf=0,top=0,width=1200,height=800,toolbar=0,scrollbars=0,sta­tus=0');
    WinPrint.document.write(prtContent.innerHTML);
    WinPrint.document.close();
    WinPrint.focus();
    WinPrint.print();
    WinPrint.close();
    prtContent.innerHTML=strOldOne;
}