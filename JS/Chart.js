
/* http://www.menucool.com/tabbed-content Free to use. Version 2013.7.6 */
//(function(){var g=function(a){if(a&&a.stopPropagation)a.stopPropagation();else window.event.cancelBubble=true;var b=a?a:window.event;b.preventDefault&&b.preventDefault()},d=function(a,c,b){if(a.addEventListener)a.addEventListener(c,b,false);else a.attachEvent&&a.attachEvent("on"+c,b)},a=function(c,a){var b=new RegExp("(^| )"+a+"( |$)");return b.test(c.className)?true:false},j=function(b,c,d){if(!a(b,c))if(b.className=="")b.className=c;else if(d)b.className=c+" "+b.className;else b.className+=" "+c},h=function(a,b){var c=new RegExp("(^| )"+b+"( |$)");a.className=a.className.replace(c,"$1");a.className=a.className.replace(/ $/,"")},e=function(){var b=window.location.pathname;if(b.indexOf("/")!=-1)b=b.split("/");var a=b[b.length-1]||"root";if(a.indexOf(".")!=-1)a=a.substring(0,a.indexOf("."));if(a>20)a=a.substring(a.length-19);return a},c="mi"+e(),b=function(b,a){this.g(b,a)};b.prototype={h:function(){var b=new RegExp(c+this.a+"=(\\d+)"),a=document.cookie.match(b);return a?a[1]:this.i()},i:function(){for(var b=0,c=this.b.length;b<c;b++)if(a(this.b[b].parentNode,"selected"))return b;return 0},j:function(b,d){var c=document.getElementById(b.TargetId);if(!c)return;this.l(c);for(var a=0;a<this.b.length;a++)if(this.b[a]==b){j(b.parentNode,"selected");d&&this.d&&this.k(this.a,a)}else h(this.b[a].parentNode,"selected")},k:function(a,b){document.cookie=c+a+"="+b+"; path=/"},l:function(b){for(var a=0;a<this.c.length;a++)this.c[a].style.display=this.c[a].id==b.id?"block":"none"},m:function(){this.c=[];for(var c=this,a=0;a<this.b.length;a++){var b=document.getElementById(this.b[a].TargetId);if(b){this.c.push(b);d(this.b[a],"click",function(b){var a=this;if(a===window)a=window.event.srcElement;c.j(a,1);g(b);return false})}}},g:function(f,h){this.a=h;this.b=[];for(var e=f.getElementsByTagName("a"),i=/#([^?]+)/,a,b,c=0;c<e.length;c++){b=e[c];a=b.getAttribute("href");if(a.indexOf("#")==-1)continue;else{var d=a.match(i);if(d){a=d[1];b.TargetId=a;this.b.push(b)}else continue}}var g=f.getAttribute("data-persist")||"";this.d=g.toLowerCase()=="true"?1:0;this.m();this.n()},n:function(){var a=this.d?parseInt(this.h()):this.i();if(a>=this.b.length)a=0;this.j(this.b[a],0)}};var k=[],i=function(e){var b=false;function a(){if(b)return;b=true;setTimeout(e,4)}if(document.addEventListener)document.addEventListener("DOMContentLoaded",a,false);else if(document.attachEvent){try{var f=window.frameElement!=null}catch(g){}if(document.documentElement.doScroll&&!f){function c(){if(b)return;try{document.documentElement.doScroll("left");a()}catch(d){setTimeout(c,10)}}c()}document.attachEvent("onreadystatechange",function(){document.readyState==="complete"&&a()})}d(window,"load",a)},f=function(){for(var d=document.getElementsByTagName("ul"),c=0,e=d.length;c<e;c++)a(d[c],"tabs")&&k.push(new b(d[c],c))};i(f);return{}})()
$(function()
{
        $('#li_temp').click(function()
        {
        $('#view1').hide();
        $('#view1').show();
        $('#tbl_view2').show();
        });
    
});

function loadSPChdnvalues()
{
$.ajax({
        url:"../Master/Default.aspx/getSPChdnvalues",
        data:'{}',
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            if(msg.d!=null && msg.d!="" && msg.d.length >0)
            {
                for(var i=0;i<msg.d.length;i++)
                {
                    $('#hdn_partno').val(msg.d[i].Partno)
                    $('#hdn_operation').val(msg.d[i].Operation)
                    $('#hdn_cell').val(msg.d[i].Cell)
                    $('#hdn_shift').val(msg.d[i].Shift)
                    $('#hdn_mach').val(msg.d[i].Machine)
                    
                    $("select[id$='ddl_partno']").val(msg.d[i].Partno);
                    $("select[id$='ddl_operation']").val(msg.d[i].Operation);
                    $("select[id$='ddl_cell']").val(msg.d[i].Cell);
                    $("select[id$='Slct_machine_QC_chart']").val(msg.d[i].Machine);
                    $("select[id$='ddl_ssize']").val('5');
                    $("select[id$='ddl_shift']").val(msg.d[i].Shift);
                    $("input[id$='hdn_mach']").val(msg.d[i].Machine);
                    $("input[id$='hdn_ssize']").val('5');
                    
                }
//                var res=validateSPCchart();
//           
//                if(res==true)
//                {
                    Spc_chartdimension();
//                }
            }

        },
        error: function (xhr, ajaxOptions, thrownError) {
//        alert('op');
        alert(xhr.status);
        alert(thrownError);
//        var err = eval("(" + xhr.responseText + ")");
//        alert(err.Message);
        }
       });
}


function validateSPCchart()
{
    if(!validatecell())return false
    if(!validatemacnine())return false
    if(!validatepart())return false
    if(!validateoper())return false
    if(!validaeshift())return false
    if(!validateSSize())return false
    return true;
}


$(function()
{

    $('#btn_chart').click(function()
    {
        var res=validateSPCchart();
       
        if(res==true)
        {
        
//             getdimension1();
//             var part=$("select[id$='ddl_partno']").val();
//             var oper=$("select[id$='ddl_operation']").val();
//             var from=$("input[id$='txt_fromdate']").val();
//             var to=$("input[id$='txt_todate']").val();
//             var shift=$("select[id$='ddl_shift']").val();
//             var mach=$("input[id$='hdn_mach']").val();
//           //   var unit=$("select[id$='ddl_unit']").val();
//               var cell=$("select[id$='ddl_cell']").val();
//             $("#div_dimensionchart").load("../DYNSheets/ChartView.aspx?Partno="+part+"&Operation="+oper+"&Dimenssion=1&From="+from+"&To="+to+"&Shift="+shift+"&Mach="+mach+"&Unit=MBU&Cell="+cell+"");
            Spc_chartdimension();
       }
    });
});

function Spc_chartdimension()
{
    var marspc=0;
     var part=$("select[id$='ddl_partno']").val();
     var oper=$("select[id$='ddl_operation']").val();
     var cell=$("select[id$='ddl_cell']").val();
     var size=$("select[id$='ddl_ssize']").val();
     
     $.ajax({
                url:"../Master/Default.aspx/getdimensionsrun",
                data:"{'Part':'"+part+"','Operation':'"+oper+"','Cell':'"+cell+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!=null && msg.d!="")
                    {   
                        $('#div_error').hide();
                        $('#div_error').addClass('hidden');
                        $('#div_dimenssion').show();
                        $('#div_dimenssion1').show();
                        $("#div_error").css("display", "none");
                        $('#error').hide();
                        var tbl='';
                        var cc=0;
                        for(var i=0;i<msg.d.length;i++)
                        {
                            if(msg.d[i].DynRefid !="")
                            {
                                if(i==0)
                                {
                                    $("input[id$='hdn_mean']").val(msg.d[i].mean);
                                    $("input[id$='hdn_dynrefid']").val(msg.d[i].DynRefid);
                                    $("input[id$='hdn_dynvalid']").val(msg.d[i].DynValid);
                                }
                                cc=cc+1;
                                //tbl+="<li onclick='javascript:showchart2("+cc+","+msg.d[i].mean+","+msg.d[i].DynRefid+","+msg.d[i].DynValid+");' ><a href='#'>"+msg.d[i].dimension+"</a></li>";
                                tbl+="<li onclick='javascript:showchart2("+msg.d[i].ColDimen+","+msg.d[i].mean+","+msg.d[i].DynRefid+","+msg.d[i].DynValid+");' ><a href='#'>"+msg.d[i].dimension+"</a></li>";
                            }
                            else
                            {
                                marspc=1;
                                cc=cc+1;
                                tbl+="<li onclick='javascript:showchart("+cc+");' ><a href='#'>"+msg.d[i].dimension+"</a></li>";
                            }
                        }

                        $('#ul_dimension').html(tbl);
                        cc=0;
                    }
                    else
                    {
                        $('#div_dimenssion').hide();
                        $('#div_dimenssion1').hide();
                        $('#div_error').show();
                        $('#div_error').removeClass('hidden');
                        document.getElementById('div_error').style.display = 'block';
                        $("#div_error").css("display", "block");
                        $('#error').show();
                    }
                    if(marspc ==0)
                    {
                         var part=$("select[id$='ddl_partno']").val();
                         var oper=$("select[id$='ddl_operation']").val();
                         var from=$("input[id$='txt_fromdate']").val();
                         var to=$("input[id$='txt_todate']").val();
                         var shift=$("select[id$='ddl_shift']").val();
                         var mach=$("input[id$='hdn_mach']").val();
                         var cell=$("select[id$='ddl_cell']").val();
                         var mean=$("input[id$='hdn_mean']").val();
                         var dynrefid=$("input[id$='hdn_dynrefid']").val();
                         var dynvalueid=$("input[id$='hdn_dynvalid']").val();
                         //$("#div_dimensionchart").load("../DYNSheets/SPCChartView.aspx?Partno="+part+"&Operation="+oper+"&Dimenssion=1&From="+from+"&To="+to+"&Shift="+shift+"&Mach="+mach+"&Unit=MBU&Cell="+cell+"&Mean="+mean+"&Dynrefid="+dynrefid+"&Size="+size+"&DynValueid="+dynvalueid+"");
                         //$("#div_dimensionchart").load("../DYNSheets/SPCChartView.aspx?Partno="+ encodeURIComponent(part)+"&Operation="+encodeURIComponent(oper)+"&Dimenssion=1&From="+ encodeURIComponent(from)+"&To="+ encodeURIComponent(to)+"&Shift="+encodeURIComponent(shift)+"&Mach="+encodeURIComponent(mach)+"&Unit=MBU&Cell="+encodeURIComponent(cell)+"&Mean="+encodeURIComponent(mean)+"&Dynrefid="+encodeURIComponent(dynrefid)+"&Size="+encodeURIComponent(size)+"&DynValueid="+encodeURIComponent(dynvalueid)+"");
                        $("#div_dimensionchart").load("../DYNSheets/SPCChartView.aspx", { "Partno": part ,"Operation":oper, "Dimenssion":"1","From":from,"To":to,"Shift":shift,"Mach":mach,"Unit":"MBU","Cell":cell,"Mean":mean,"Dynrefid":dynrefid,"DynValueid":dynvalueid,"Size": size }, function () {
                            ////callback function implementation
                        });
                     }
                     else
                     {
                         var part=$("select[id$='ddl_partno']").val();
                         var oper=$("select[id$='ddl_operation']").val();
                         var from=$("input[id$='txt_fromdate']").val();
                         var to=$("input[id$='txt_todate']").val();
                         var shift=$("select[id$='ddl_shift']").val();
                         var mach=$("input[id$='hdn_mach']").val();
                       //   var unit=$("select[id$='ddl_unit']").val();
                         var cell=$("select[id$='ddl_cell']").val();
                         $("#div_dimensionchart").load("../DYNSheets/ChartView.aspx?Partno="+encodeURIComponent(part)+"&Operation="+encodeURIComponent(oper)+"&Dimenssion=1&From="+encodeURIComponent(from)+"&To="+encodeURIComponent(to)+"&Shift="+encodeURIComponent(shift)+"&Mach="+encodeURIComponent(mach)+"&Unit=MBU&Cell="+encodeURIComponent(cell)+"&Size="+encodeURIComponent(size)+"");
                     }
             
                },
                error:function()
                {}
              });
}

$(function()
{
    $('#btn_runchart').click(function()
    {
        var res=validatechart();
       
        if(res==true)
        {
            eachgetdimension1();
        }
    });
});
function validatechart()
{
    //if(!validatetype())return false
    //if(!validateunit())return false
    if(!validatecell())return false
    if(!validatemacnine())return false
    if(!validatepart())return false
    if(!validateoper())return false
    //if(!validatedimension())return false
    if(!validaeshift())return false
    return true;
}
function validatetype()
{
     var type=$("select[id$='ddl_type']").val();
     if(type=="" || type==null || type=="0")
     {
        alert("Select Type");
        return false;
     }
     else
     {
        
       return true;
     }
}
function validateunit()
{
     var unit=$("select[id$='ddl_unit_QC_chart']").val();
     if(unit=="" || unit==null || unit=="0")
     {
        alert("Select Unit");
        return false;
     }
     else
     {
     $("input[id$='hdn_unit1']").val(unit);
       return true;
     }
}
function validatecell()
{
     var cell=$("select[id$='ddl_cell']").val();
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
function validatemacnine()
{
     var mach=$("select[id$='Slct_machine_QC_chart']").val();
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
function validatepart()
{
     var part=$("select[id$='ddl_partno']").val();
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
function validateoper()
{
     var oper=$("select[id$='ddl_operation']").val();
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
function validatedimension()
{
     var dim=$("select[id$='ddl_dimesion']").val();
     if(dim=="" || dim==null || dim=="0")
     {
        alert("Select Dimension");
        return false;
     }
     else
     {
     $("input[id$='hdn_dimesion']").val(dim);
       return true;
     }
}
function validaeshift()
{
     var shift=$("select[id$='ddl_shift']").val();
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
function validateSSize()
{
     var ssize=$("select[id$='ddl_ssize']").val();
     if(ssize=="" || ssize==null || ssize=="0")
     {
        alert("Select Sample Size");
        return false;
     }
     else
     {
     $("input[id$='hdn_ssize']").val(ssize);
       return true;
     }
}
function getmachine1()
{
        var dept=$("select[id$='ddl_unit_QC_chart']").val();
        $.ajax({
                url:"../Master/Default.aspx/getdepartment",
                data:"{'unit':'MBU'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    $("select[id$='ddl_cell']").get(0).options.length = 0;
                    $("select[id$='ddl_cell']").get(0).options[0] = new Option("--- Select Cell ---", "0");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='ddl_cell']").get(0).options[$("select[id$='ddl_cell']").get(0).options.length] = new Option(comma[count], comma[count]);
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
        var dept=$("select[id$='ddl_cell']").val();
        $.ajax({
                url:"../Master/Default.aspx/getmachinename",
                data:"{'dept':'"+dept+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    $("select[id$='Slct_machine_QC_chart']").get(0).options.length = 0;
                    $("select[id$='Slct_machine_QC_chart']").get(0).options[0] = new Option("--- Select Machine ---", "0");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='Slct_machine_QC_chart']").get(0).options[$("select[id$='Slct_machine_QC_chart']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    
                    var M=$("input[id$='hdn_mach']").val();
                    if(M!="")
                    {
                        $("select[id$='Slct_machine_QC_chart']").val(M);
                    }
//                    if($("select[id$='Slct_machine_QC_chart']").val() == "--- Select Machine ---" || $("select[id$='Slct_machine_QC_chart']").val() == "0")
//                    {
//                        var M=$("input[id$='hdn_mach']").val();
//                        if(M!="")
//                        {
//                            $("select[id$='Slct_machine_QC_chart']").val(M);
//                        }
//                    }
                    part=null;
                    comma=null;
                    
              },
                error: function (xhr, ajaxOptions, thrownError) {
                alert('mach');
                alert(xhr.status);
                alert(thrownError);
                var err = eval("(" + xhr.responseText + ")");
                alert(err.Message);
                }
              });
}

function getsamplesize()
{
$.ajax({
        url:"../Master/Default.aspx/getSPCValues",
        data:"",
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
        
            $("select[id$='ddl_ssize']").get(0).options.length = 0;
            $("select[id$='ddl_ssize']").get(0).options[0] = new Option("--- Select Sample Size ---", "0");
            part=msg.d;
            comma=part.split(",");
            for(var count=0;count<comma.length;count++)
            {
                if(comma[count]=="")
                {
                }
                else
                {
                    $("select[id$='ddl_ssize']").get(0).options[$("select[id$='ddl_ssize']").get(0).options.length] = new Option(comma[count], comma[count]);
                }
            }
            
            var M=$("input[id$='hdn_ssize']").val();
            if(M!="")
            {
                $("select[id$='ddl_ssize']").val(M);
            }
            
            part=null;
            comma=null;
            
      },
        error:function()
        {}
      });
}

function getdimension()
{
     var part=$("select[id$='ddl_partno']").val();
     var oper=$("select[id$='ddl_operation']").val();
     if(oper=="OP1")
     {
        oper='1';
     }
     if(oper=="OP2")
     {
        oper='2';
     }
      $.ajax({
                url:"../Master/Default.aspx/getdimensions",
                data:"{'Part':'"+part+"','Operation':'"+oper+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    $("select[id$='ddl_dimesion']").get(0).options.length = 0;
                    $("select[id$='ddl_dimesion']").get(0).options[0] = new Option("--- Select Machine ---", "0");
                    part=msg.d;
                    comma=part.split(",");
                    var c=0;
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='ddl_dimesion']").get(0).options[$("select[id$='ddl_dimesion']").get(0).options.length] = new Option(comma[count],c+=1);
                        }
                    }
                    c=0;
                    part=null;
                    comma=null;
                    
              },
                error:function()
                {}
              });
}
function getdimension1()
{
     var part=$("select[id$='ddl_partno']").val();
     var oper=$("select[id$='ddl_operation']").val();
     var cell=$("select[id$='ddl_cell']").val();
     $.ajax({
                url:"../Master/Default.aspx/getdimensions",
                data:"{'Part':'"+part+"','Operation':'"+oper+"','Cell':'"+cell+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                
                    if(msg.d!=null && msg.d!="")
                    {   
                        $('#div_dimenssion').show();
                        $('#div_dimenssion1').show();
                        $('#div_error').hide();
                        var tbl='';
                        part=msg.d;
                        comma=part.split(",");
                        var cc=0;
                        for(var count=0;count<comma.length;count++)
                        {
                            if(comma[count]=="")
                            {
                            }
                            else
                            {
                                cc=cc+1;
                                tbl+="<li onclick='javascript:showchart("+cc+");' ><a href='#'>"+comma[count]+"</a></li>";
                            }
                        }
                        $('#ul_dimension').html(tbl);
                        cc=0;
                        part=null;
                        comma=null;
                    }
                    else
                    {
                        $('#div_dimenssion').hide();
                        $('#div_dimenssion1').hide();
                        $('#div_error').show();
                    }
                },
                error:function()
                {}
              });
}
function eachgetdimension1()
{

     var part=$("select[id$='ddl_partno']").val();
     var oper=$("select[id$='ddl_operation']").val();
     var cell=$("select[id$='ddl_cell']").val();
     $.ajax({
                url:"../Master/Default.aspx/getdimensionsrun",
                data:"{'Part':'"+part+"','Operation':'"+oper+"','Cell':'"+cell+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!=null && msg.d!="")
                    {   
                        $('#div_dimenssion').show();
                        $('#div_dimenssion1').show();
                        $('#div_error').hide();
                        var tbl='';
                        var cc=0;
                        for(var i=0;i<msg.d.length;i++)
                        {
                            if(i==0)
                            {
                                $("input[id$='hdn_mean']").val(msg.d[i].mean);
                                $("input[id$='hdn_dynrefid']").val(msg.d[i].DynRefid);
                                $("input[id$='hdn_dynvalid']").val(msg.d[i].DynValid);
                            }
                            cc=cc+1;
                            //tbl+="<li onclick='javascript:showchart1("+cc+","+msg.d[i].mean+","+msg.d[i].DynRefid+","+msg.d[i].DynValid+");' ><a href='#'>"+msg.d[i].dimension+"</a></li>";
                            tbl+="<li onclick='javascript:showchart1("+msg.d[i].ColDimen+","+msg.d[i].mean+","+msg.d[i].DynRefid+","+msg.d[i].DynValid+");' ><a href='#'>"+msg.d[i].dimension+"</a></li>";
                        }
//                        part=msg.d;
//                        comma=part.split(",");
//                        var cc=0;
//                        for(var count=0;count<comma.length;count++)
//                        {
//                            if(comma[count]=="")
//                            {
//                            }
//                            else
//                            {
//                                
//                                if(cc==0)
//                                {
//                                    $("input[id$='hdn_mean']").val(comma[count]);
//                                }
//                                cc=cc+1;
//                                tbl+="<li onclick='javascript:showchart1("+cc+","+comma[count]+");' ><a href='#'>"+comma[count]+"</a></li>";
//                            }
//                        }
                        $('#ul_dimension').html(tbl);
                        cc=0;
//                        part=null;
//                        comma=null;
                    }
                    else
                    {
                        $('#div_dimenssion').hide();
                        $('#div_dimenssion1').hide();
                        $('#div_error').show();
                    }
                    
                     var part=$("select[id$='ddl_partno']").val();
                     var oper=$("select[id$='ddl_operation']").val();
                     var from=$("input[id$='txt_fromdate']").val();
                     var to=$("input[id$='txt_todate']").val();
                     var shift=$("select[id$='ddl_shift']").val();
                     var mach=$("input[id$='hdn_mach']").val();
                   //   var unit=$("select[id$='ddl_unit']").val();
                       var cell=$("select[id$='ddl_cell']").val();
                       var mean=$("input[id$='hdn_mean']").val();
                       var dynrefid=$("input[id$='hdn_dynrefid']").val();
                       var dynvalueid=$("input[id$='hdn_dynvalid']").val();
                     //$("#div_dimensionchart").load("../DYNSheets/RunChartView.aspx?Partno="+encodeURIComponent(part)+"&Operation="+encodeURIComponent(oper)+"&Dimenssion=1&From="+encodeURIComponent(from)+"&To="+encodeURIComponent(to)+"&Shift="+encodeURIComponent(shift)+"&Mach="+encodeURIComponent(mach)+"&Unit=MBU&Cell="+encodeURIComponent(cell)+"&Mean="+encodeURIComponent(mean)+"&Dynrefid="+encodeURIComponent(dynrefid)+"&DynValueid="+encodeURIComponent(dynvalueid)+"");
                     $("#div_dimensionchart").load("../DYNSheets/RunChartView.aspx", { "Partno": part ,"Operation":oper, "Dimenssion":"1","From":from,"To":to,"Shift":shift,"Mach":mach,"Unit":"MBU","Cell":cell,"Mean":mean,"Dynrefid":dynrefid,"DynValueid":dynvalueid }, function () {
                        ////callback function implementation
                    });
             
                },
                error:function()
                {}
              });
}
function showchart(dimension)
{
     var part=$("select[id$='ddl_partno']").val();
     var oper=$("select[id$='ddl_operation']").val();
     var from=$("input[id$='txt_fromdate']").val();
     var to=$("input[id$='txt_todate']").val();
     var shift=$("select[id$='ddl_shift']").val();
     var mach=$("input[id$='hdn_mach']").val();
     var cell=$("select[id$='ddl_cell']").val();
     var size=$("select[id$='ddl_ssize']").val();
     //$("#div_dimensionchart").load("../DYNSheets/ChartView.aspx?Partno="+part+"&Operation="+oper+"&Dimenssion="+dimension+"&From="+from+"&To="+to+"&Shift="+shift+"&Mach="+mach+"&Unit=MBU&Cell="+cell+"");
     $("#div_dimensionchart").load("../DYNSheets/ChartView.aspx?Partno="+encodeURIComponent(part)+"&Operation="+encodeURIComponent(oper)+"&Dimenssion=1&From="+encodeURIComponent(from)+"&To="+encodeURIComponent(to)+"&Shift="+encodeURIComponent(shift)+"&Mach="+encodeURIComponent(mach)+"&Unit=MBU&Cell="+encodeURIComponent(cell)+"&Size="+encodeURIComponent(size)+"");
     
}
function showchart1(dimension,mean,dynrefid,dynvalueid)
{
     var part=$("select[id$='ddl_partno']").val();
     var oper=$("select[id$='ddl_operation']").val();
     var from=$("input[id$='txt_fromdate']").val();
     var to=$("input[id$='txt_todate']").val();
     var shift=$("select[id$='ddl_shift']").val();
     var mach=$("input[id$='hdn_mach']").val();
     var cell=$("select[id$='ddl_cell']").val();
     //$("#div_dimensionchart").load("../DYNSheets/RunChartView.aspx?Partno="+part+"&Operation="+oper+"&Dimenssion="+dimension+"&From="+from+"&To="+to+"&Shift="+shift+"&Mach="+mach+"&Unit=MBU&Cell="+cell+"&Mean="+mean+"&Dynrefid="+dynrefid+"&DynValueid="+dynvalueid+"");
     //$("#div_dimensionchart").load("../DYNSheets/RunChartView.aspx?Partno="+encodeURIComponent(part)+"&Operation="+encodeURIComponent(oper)+"&Dimenssion=1&From="+encodeURIComponent(from)+"&To="+encodeURIComponent(to)+"&Shift="+encodeURIComponent(shift)+"&Mach="+encodeURIComponent(mach)+"&Unit=MBU&Cell="+encodeURIComponent(cell)+"&Mean="+encodeURIComponent(mean)+"&Dynrefid="+encodeURIComponent(dynrefid)+"&DynValueid="+encodeURIComponent(dynvalueid)+"");
    $("#div_dimensionchart").load("../DYNSheets/RunChartView.aspx", { "Partno": part ,"Operation":oper, "Dimenssion":dimension,"From":from,"To":to,"Shift":shift,"Mach":mach,"Unit":"MBU","Cell":cell,"Mean":mean,"Dynrefid":dynrefid,"DynValueid":dynvalueid }, function () {
        ////callback function implementation
    });
     
}    
function showchart2(dimension,mean,dynrefid,dynvalueid)
{

     var part=$("select[id$='ddl_partno']").val();
     var oper=$("select[id$='ddl_operation']").val();
     var from=$("input[id$='txt_fromdate']").val();
     var to=$("input[id$='txt_todate']").val();
     var shift=$("select[id$='ddl_shift']").val();
     var mach=$("input[id$='hdn_mach']").val();
     var cell=$("select[id$='ddl_cell']").val();
     var size=$("select[id$='ddl_ssize']").val();
     //$("#div_dimensionchart").load("../DYNSheets/SPCChartView.aspx?Partno="+part+"&Operation="+oper+"&Dimenssion="+dimension+"&From="+from+"&To="+to+"&Shift="+shift+"&Mach="+mach+"&Unit=MBU&Cell="+cell+"&Mean="+mean+"&Dynrefid="+dynrefid+"&Size="+size+"&DynValueid="+dynvalueid+"");
     //$("#div_dimensionchart").load("../DYNSheets/SPCChartView.aspx?Partno="+ encodeURIComponent(part)+"&Operation="+encodeURIComponent(oper)+"&Dimenssion=1&From="+ encodeURIComponent(from)+"&To="+ encodeURIComponent(to)+"&Shift="+encodeURIComponent(shift)+"&Mach="+encodeURIComponent(mach)+"&Unit=MBU&Cell="+encodeURIComponent(cell)+"&Mean="+encodeURIComponent(mean)+"&Dynrefid="+encodeURIComponent(dynrefid)+"&Size="+encodeURIComponent(size)+"&DynValueid="+encodeURIComponent(dynvalueid)+"");
    $("#div_dimensionchart").load("../DYNSheets/SPCChartView.aspx", { "Partno": part ,"Operation":oper, "Dimenssion":dimension,"From":from,"To":to,"Shift":shift,"Mach":mach,"Unit":"MBU","Cell":cell,"Mean":mean,"Dynrefid":dynrefid,"DynValueid":dynvalueid,"Size": size}, function () {
        ////callback function implementation
    });
}   
function loadhdnvalues()
{
$.ajax({
        url:"../Master/Default.aspx/gethdnvalues",
        data:'{}',
        type:"POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            if(msg.d!=null && msg.d!="")
            {
                for(var i=0;i<msg.d.length;i++)
                {
                    $('#hdn_partno').val(msg.d[i].Partno)
                    $('#hdn_operation').val(msg.d[i].Operation)
                    $('#hdn_cell').val(msg.d[i].Cell)
                    $('#hdn_shift').val(msg.d[i].Shift)
                    $('#hdn_mach').val(msg.d[i].Machine)
                    
                    $("select[id$='ddl_partno']").val(msg.d[i].Partno);
                    $("select[id$='ddl_operation']").val(msg.d[i].Operation);
                    $("select[id$='ddl_cell']").val(msg.d[i].Cell);
                    $("select[id$='Slct_machine_QC_chart']").val(msg.d[i].Machine);
                    //getmachine();
                    $("select[id$='ddl_shift']").val(msg.d[i].Shift);
                    $("input[id$='hdn_mach']").val(msg.d[i].Machine);
                }
            }
            eachgetdimension1();
            //loadchart();
        },
        error: function (xhr, ajaxOptions, thrownError) {
//        alert('op');
        alert(xhr.status);
        alert(thrownError);
//        var err = eval("(" + xhr.responseText + ")");
//        alert(err.Message);
        }
       });
}

function loadchart()
{

    var part=$('#hdn_partno').val();
     var oper=$('#hdn_operation').val();
     var cell=$('#hdn_cell').val();
     $.ajax({
                url:"../Master/Default.aspx/getdimensionsrun",
                data:"{'Part':'"+part+"','Operation':'"+oper+"','Cell':'"+cell+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
                    if(msg.d!=null && msg.d!="")
                    {   
                        $('#div_dimenssion').show();
                        $('#div_dimenssion1').show();
                        $('#div_error').hide();
                        var tbl='';
                        var cc=0;
                        for(var i=0;i<msg.d.length;i++)
                        {
                            if(i==0)
                            {
                                $("input[id$='hdn_mean']").val(msg.d[i].mean);
                                $("input[id$='hdn_dynrefid']").val(msg.d[i].DynRefid);
                                $("input[id$='hdn_dynvalid']").val(msg.d[i].DynValid);
                            }
                            cc=cc+1;
//                            tbl+="<li onclick='javascript:showchart1("+cc+","+msg.d[i].mean+","+msg.d[i].DynRefid+","+msg.d[i].DynValid+");' ><a href='#'>"+msg.d[i].dimension+"</a></li>";
tbl+="<li onclick='javascript:showchart1("+msg.d[i].ColDimen+","+msg.d[i].mean+","+msg.d[i].DynRefid+","+msg.d[i].DynValid+");' ><a href='#'>"+msg.d[i].dimension+"</a></li>";
                        }
//                        part=msg.d;
//                        comma=part.split(",");
//                        var cc=0;
//                        for(var count=0;count<comma.length;count++)
//                        {
//                            if(comma[count]=="")
//                            {
//                            }
//                            else
//                            {
//                                
//                                if(cc==0)
//                                {
//                                    $("input[id$='hdn_mean']").val(comma[count]);
//                                }
//                                cc=cc+1;
//                                tbl+="<li onclick='javascript:showchart1("+cc+","+comma[count]+");' ><a href='#'>"+comma[count]+"</a></li>";
//                            }
//                        }
                        $('#ul_dimension').html(tbl);
                        cc=0;
//                        part=null;
//                        comma=null;
                    }
                    else
                    {
                        $('#div_dimenssion').hide();
                        $('#div_dimenssion1').hide();
                        $('#div_error').show();
                    }
                    
                     var part=$('#hdn_part').val();
                     var oper=$('#hdn_operation').val();
                     var from=$("input[id$='txt_fromdate']").val();
                     var to=$("input[id$='txt_todate']").val();
                     var shift=$("hdn_shift").val();
                     var mach=$('#hdn_mach').val();
                   //   var unit=$("select[id$='ddl_unit']").val();
                     var cell=$('#hdn_cell').val();
                     var mean=$("input[id$='hdn_mean']").val();
                     var dynrefid=$("input[id$='hdn_dynrefid']").val();
                     var dynvalueid=$("input[id$='hdn_dynvalid']").val();
                     //$("#div_dimensionchart").load("../DYNSheets/RunChartView.aspx?Partno="+part+"&Operation="+oper+"&Dimenssion=1&From="+from+"&To="+to+"&Shift="+shift+"&Mach="+mach+"&Unit=MBU&Cell="+cell+"&Mean="+mean+"&Dynrefid="+dynrefid+"&DynValueid="+dynvalueid+"");
                     //$("#div_dimensionchart").load("../DYNSheets/RunChartView.aspx?Partno="+encodeURIComponent(part)+"&Operation="+encodeURIComponent(oper)+"&Dimenssion=1&From="+encodeURIComponent(from)+"&To="+encodeURIComponent(to)+"&Shift="+encodeURIComponent(shift)+"&Mach="+encodeURIComponent(mach)+"&Unit=MBU&Cell="+encodeURIComponent(cell)+"&Mean="+encodeURIComponent(mean)+"&Dynrefid="+encodeURIComponent(dynrefid)+"&DynValueid="+encodeURIComponent(dynvalueid)+"");
                     $("#div_dimensionchart").load("../DYNSheets/RunChartView.aspx", { "Partno": part ,"Operation":oper, "Dimenssion":"1","From":from,"To":to,"Shift":shift,"Mach":mach,"Unit":"MBU","Cell":cell,"Mean":mean,"Dynrefid":dynrefid,"DynValueid":dynvalueid }, function () {
                        ////callback function implementation
                    });
             
                },
                error:function()
                {}
              });
}

function SPCvaluesFunc(usl,lsl,mean,ucl,lcl,pmean)
{
    $("span[id$='spn_spcUSL']").text(usl);
    $("span[id$='spn_spcLSL']").text(lsl);
    $("span[id$='spn_spcMean']").text(mean);
    $("span[id$='spn_spcUCL']").text(ucl);
    $("span[id$='spn_spcLCL']").text(lcl);
    $("span[id$='spn_spcPMean']").text(pmean);
}

function RunvaluesFunc(usl,lsl,mean,ucl,lcl,pmean)
{
    $("span[id$='spn_runUSL']").text(usl);
    $("span[id$='spn_runLSL']").text(lsl);
    $("span[id$='spn_runMean']").text(mean);
    $("span[id$='spn_runUCL']").text(ucl);
    $("span[id$='spn_runLCL']").text(lcl);
    $("span[id$='spn_runPMean']").text(pmean);
}