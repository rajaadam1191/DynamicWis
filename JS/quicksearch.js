(function ($, window, document, undefined) {
    $.fn.quicksearch = function (target, opt) {

        var timeout, cache, rowcache, jq_results, val = '', e = this, options = $.extend({
            delay: 100,
            selector: null,
            stripeRows: null,
            loader: null,
            noResults: '',
            matchedResultsCount: 0,
            bind: 'keyup',
            onBefore: function () {
                return;
            },
            onAfter: function () {
                return;
            },
            show: function () {
                this.style.display = "";
            },
            hide: function () {
                this.style.display = "none";
            },
            prepareQuery: function (val) {
                return val.toLowerCase().split(' ');
            },
            testQuery: function (query, txt, _row) {
                for (var i = 0; i < query.length; i += 1) {
                    if (txt.indexOf(query[i]) === -1) {
                        return false;
                    }
                }
                return true;
            }
        }, opt);

        this.go = function () {

            var i = 0,
				numMatchedRows = 0,
				noresults = true,
				query = options.prepareQuery(val),
				val_empty = (val.replace(' ', '').length === 0);

            for (var i = 0, len = rowcache.length; i < len; i++) {
                if (val_empty || options.testQuery(query, cache[i], rowcache[i])) {
                    options.show.apply(rowcache[i]);
                    noresults = false;
                    numMatchedRows++;
                } else {
                    options.hide.apply(rowcache[i]);
                }
            }

            if (noresults) {
                this.results(false);
            } else {
                this.results(true);
                this.stripe();
            }

            this.matchedResultsCount = numMatchedRows;
            this.loader(false);
            options.onAfter();

            return this;
        };

        /*
        * External API so that users can perform search programatically. 
        * */
        this.search = function (submittedVal) {
            val = submittedVal;
            e.trigger();
        };

        /*
        * External API to get the number of matched results as seen in 
        * https://github.com/ruiz107/quicksearch/commit/f78dc440b42d95ce9caed1d087174dd4359982d6
        * */
        this.currentMatchedResults = function () {
            return this.matchedResultsCount;
        };

        this.stripe = function () {

            if (typeof options.stripeRows === "object" && options.stripeRows !== null) {
                var joined = options.stripeRows.join(' ');
                var stripeRows_length = options.stripeRows.length;

                jq_results.not(':hidden').each(function (i) {
                    $(this).removeClass(joined).addClass(options.stripeRows[i % stripeRows_length]);
                });
            }

            return this;
        };

        this.strip_html = function (input) {
            var output = input.replace(new RegExp('<[^<]+\>', 'g'), "");
            output = $.trim(output.toLowerCase());
            return output;
        };

        this.results = function (bool) {
            if (typeof options.noResults === "string" && options.noResults !== "") {
                if (bool) {
                    $(options.noResults).hide();
                } else {
                    $(options.noResults).show();
                }
            }
            return this;
        };

        this.loader = function (bool) {
            if (typeof options.loader === "string" && options.loader !== "") {
                (bool) ? $(options.loader).show() : $(options.loader).hide();
            }
            return this;
        };

        this.cache = function () {

            jq_results = $(target);

            if (typeof options.noResults === "string" && options.noResults !== "") {
                jq_results = jq_results.not(options.noResults);
            }

            var t = (typeof options.selector === "string") ? jq_results.find(options.selector) : $(target).not(options.noResults);
            cache = t.map(function () {
                return e.strip_html(this.innerHTML);
            });

            rowcache = jq_results.map(function () {
                return this;
            });

            /*
            * Modified fix for sync-ing "val". 
            * Original fix https://github.com/michaellwest/quicksearch/commit/4ace4008d079298a01f97f885ba8fa956a9703d1
            * */
            val = val || this.val() || "";

            return this.go();
        };

        this.trigger = function () {
            this.loader(true);
            options.onBefore();

            window.clearTimeout(timeout);
            timeout = window.setTimeout(function () {
                e.go();
            }, options.delay);

            return this;
        };

        this.cache();
        this.results(true);
        this.stripe();
        this.loader(false);

        return this.each(function () {

            /*
            * Changed from .bind to .on.
            * */
            $(this).on(options.bind, function () {

                val = $(this).val();
                e.trigger();
            });
        });

    };

} (jQuery, this, document));




$(function()
{
    $('#link_one').click(function()
    {
       $('#view1').show();
       $('#view2').hide();
       $('#view3').hide();
    });
});
$(function()
{
    $('#link_two').click(function()
    {
        two();
    });
});
$(function()
{
    $('#link_three').click(function()
    { 
         $('#view1').hide();
         $('#view2').hide();
//         $('#view3').show();
//         loadfixturechange();
    });
});
function one()
{
         $('#view1').show();
         $('#view2').hide();
         $('#view3').hide();
}
function two()
{

         $('#view1').hide();
         $('#view2').show();
         $('#view3').hide();
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
               
                    $("select[id$='ddl_partno']").get(0).options.length = 0;
                    $("select[id$='ddl_partno']").get(0).options[0] = new Option("--- Select Part Number ---", "0");
                    $("select[id$='ddl_partno']").get(0).options[1] = new Option("ALL", "ALL");
                    
                     $("select[id$='ddl_cpartno']").get(0).options.length = 0;
                    $("select[id$='ddl_cpartno']").get(0).options[0] = new Option("--- Select Part Number ---", "0");
                    $("select[id$='ddl_cpartno']").get(0).options[1] = new Option("ALL", "ALL");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='ddl_partno']").get(0).options[$("select[id$='ddl_partno']").get(0).options.length] = new Option(comma[count], comma[count]);
                            $("select[id$='ddl_cpartno']").get(0).options[$("select[id$='ddl_cpartno']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    part=null;
                    comma=null;
                    GetFixProcess();
              },
                error:function()
                {}
              });
              
}
function GetFixProcess()
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
            $("select[id$='ddl_operation']").get(0).options.length = 0;
            $("select[id$='ddl_operation']").get(0).options[0] = new Option("--- Select Operation ---", "0");
            
            $("select[id$='ddl_coperation']").get(0).options.length = 0;
            $("select[id$='ddl_coperation']").get(0).options[0] = new Option("--- Select Operation ---", "0");
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
                        $("select[id$='ddl_operation']").get(0).options[$("select[id$='ddl_operation']").get(0).options.length] = new Option(comma[count], "1");                            
                        $("select[id$='ddl_coperation']").get(0).options[$("select[id$='ddl_coperation']").get(0).options.length] = new Option(comma[count], "1");
                    }
                    else if(comma[count]=="OP2")
                    {
                        $("select[id$='ddl_operation']").get(0).options[$("select[id$='ddl_operation']").get(0).options.length] = new Option(comma[count], "2");
                        $("select[id$='ddl_coperation']").get(0).options[$("select[id$='ddl_coperation']").get(0).options.length] = new Option(comma[count], "2");
                    }
                    else
                    {
                        $("select[id$='ddl_operation']").get(0).options[$("select[id$='ddl_operation']").get(0).options.length] = new Option(comma[count], comma[count]);
                        $("select[id$='ddl_coperation']").get(0).options[$("select[id$='ddl_coperation']").get(0).options.length] = new Option(comma[count], comma[count]);
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

function getfixno()
{
    var part=$("select[id$='ddl_partno']").val();
    $.ajax({
                url:"../Master/Default.aspx/Get_fixname",
                data:"{'ID':'"+part+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
              
                    $("select[id$='ddl_fixno']").get(0).options.length = 0;
                    $("select[id$='ddl_fixno']").get(0).options[0] = new Option("--- Select Fixture Name ---", "0");
                   // $("select[id$='ddl_fixno']").get(0).options[1] = new Option("ALL", "ALL");
                    
                     $("select[id$='ddl_cfixno']").get(0).options.length = 0;
                    $("select[id$='ddl_cfixno']").get(0).options[0] = new Option("--- Select Fixture Name ---", "0");
                    $("select[id$='ddl_cfixno']").get(0).options[1] = new Option("ALL", "ALL");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='ddl_fixno']").get(0).options[$("select[id$='ddl_fixno']").get(0).options.length] = new Option(comma[count], comma[count]);
                            $("select[id$='ddl_cfixno']").get(0).options[$("select[id$='ddl_cfixno']").get(0).options.length] = new Option(comma[count], comma[count]);
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
                    $("select[id$='ddl_machine']").get(0).options.length = 0;
                    $("select[id$='ddl_machine']").get(0).options[0] = new Option("--- Select Machine Name ---", "0");
                    // $("select[id$='ddl_machine']").get(0).options[1] = new Option("ALL", "ALL");
                     
                     $("select[id$='ddl_cmachine']").get(0).options.length = 0;
                    $("select[id$='ddl_cmachine']").get(0).options[0] = new Option("--- Select Machine Name ---", "0");
                     //$("select[id$='ddl_cmachine']").get(0).options[1] = new Option("ALL", "ALL");
                    part=msg.d;
                    comma=part.split(",");
                    for(var count=0;count<comma.length;count++)
                    {
                        if(comma[count]=="")
                        {
                        }
                        else
                        {
                            $("select[id$='ddl_machine']").get(0).options[$("select[id$='ddl_machine']").get(0).options.length] = new Option(comma[count], comma[count]);
                            $("select[id$='ddl_cmachine']").get(0).options[$("select[id$='ddl_cmachine']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    
                    part=null;
                    comma=null;
                    
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
                    $("select[id$='ddl_machine']").get(0).options.length = 0;
                    $("select[id$='ddl_machine']").get(0).options[0] = new Option("--- Select Machine Name ---", "0");
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
                            $("select[id$='ddl_machine']").get(0).options[$("select[id$='ddl_machine']").get(0).options.length] = new Option(comma[count], comma[count]);
                            $("select[id$='ddl_cmachine']").get(0).options[$("select[id$='ddl_cmachine']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    
                    part=null;
                    comma=null;
                    
              },
                error:function()
                {}
              });
}
function checksearch()
{
    //if(!v_partno())return false
    if(!v_fno())return false
    if(!v_op())return false
    if(!v_mach())return false
}
function v_partno()
{
    var part= $("select[id$='ddl_partno']").val();
     $("input[id$='hdn_part']").val(part);
    if(part =="0")
    {
        $('#div_error').show();
        $('#spn_error').text('Select Part No');
         $("select[id$='ddl_partno']").focus();
        return false;
    }
    else
    {
          $('#div_error').hide();
        return true;
    }
}
function v_op()
{
    var op= $("select[id$='ddl_operation']").val();
    $("input[id$='hdn_op']").val(op);
    if(op =="0")
    {
        $('#div_error').show();
        $('#spn_error').text('Select Operation');
         $("select[id$='ddl_operation']").focus();
        return false;
    }
    else
    {
          $('#div_error').hide();
        return true;
    }
}
function v_fno()
{
     var fix= $("select[id$='ddl_fixno']").val();
     $("input[id$='hdn_fix']").val(fix);
    if(fix =="0")
    {
        $('#div_error').show();
        $('#spn_error').text('Select Fixture No');
         $("select[id$='ddl_fixno']").focus();
        return false;
    }
    else
    {
          $('#div_error').hide();
        return true;
    }
}
function v_mach()
{
     var mach= $("select[id$='ddl_machine']").val();
     $("input[id$='hdn_mach']").val(mach);
    if(mach =="0")
    {
        $('#div_error').show();
        $('#spn_error').text('Select Machine');
         $("select[id$='ddl_machine']").focus();
        return false;
    }
    else
    {
          $('#div_error').hide();
        return true;
    }
}


function getfixno1()
{
    var part=$("select[id$='ddl_cpartno']").val();
    $.ajax({
                url:"../Master/Default.aspx/Get_fixname",
                data:"{'ID':'"+part+"'}",
                type:"POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(msg)
                {
              
                    $("select[id$='ddl_cfixno']").get(0).options.length = 0;
                    $("select[id$='ddl_cfixno']").get(0).options[0] = new Option("--- Select Fixture Name ---", "0");
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
                            $("select[id$='ddl_cfixno']").get(0).options[$("select[id$='ddl_cfixno']").get(0).options.length] = new Option(comma[count], comma[count]);
                        }
                    }
                    
                    part=null;
                    comma=null;
                    
              },
                error:function()
                {}
              });
}
function checkcalibrte()
{
    if(!va_partno())return false
    if(!va_fixno())return false
    if(!va_operation())return false
    if(!va_machine())return false
    if(!va_year())return false
    if(!va_month())return false
     if(!va_month1())return false
}
function va_partno()
{
    var part= $("select[id$='ddl_cpartno']").val();
    
    if(part =="0")
    {
        $('#div_caerror').show();
        $('#spn_caerror').text('Select Part No');
         $("select[id$='ddl_cpartno']").focus();
        return false;
    }
    else
    {
          $('#div_caerror').hide();
           $("input[id$='hdn_part1']").val(part);
        return true;
    }
}
function va_fixno()
{
    var fix= $("select[id$='ddl_cfixno']").val();
    
    if(fix =="0")
    {
        $('#div_caerror').show();
        $('#spn_caerror').text('Select Fix No');
         $("select[id$='ddl_cfixno']").focus();
        return false;
    }
    else
    {
          $('#div_caerror').hide();
           $("input[id$='hdn_fix1']").val(fix);
        return true;
    }
}
function va_operation()
{
    var ope= $("select[id$='ddl_coperation']").val();
     
    if(ope =="0")
    {
        $('#div_caerror').show();
        $('#spn_caerror').text('Select Operation');
         $("select[id$='ddl_coperation']").focus();
        return false;
    }
    else
    {
          $('#div_caerror').hide();
          $("input[id$='hdn_op1']").val(ope);
        return true;
    }
}
function va_machine()
{
    var mach= $("select[id$='ddl_cmachine']").val();
    
    if(mach =="0")
    {
        $('#div_caerror').show();
        $('#spn_caerror').text('Select Machine');
         $("select[id$='ddl_cmachine1']").focus();
        return false;
    }
    else
    {
          $('#div_caerror').hide();
          $("input[id$='hdn_mach1']").val(mach);
        return true;
    }
}
function va_year()
{
    var year= $("select[id$='ddl_year']").val();
     
    if(year =="0" || year=="--- Select Year ---")
    {
        $('#div_caerror').show();
        $('#spn_caerror').text('Select Year');
         $("select[id$='ddl_year']").focus();
        return false;
    }
    else
    {
          $('#div_caerror').hide();
          $("input[id$='hdn_year']").val(year);
        return true;
    }
}
function va_month()
{
    var month= $("select[id$='ddl_month']").val();
     $("input[id$='hdn_month']").val(month);
    if(month =="0")
    {
        $('#div_caerror').show();
        $('#spn_caerror').text('Select Month');
         $("select[id$='ddl_month']").focus();
        return false;
    }
    else
    {
          $('#div_caerror').hide();
        return true;
    }
}
function va_month1()
{
    var month1= $("select[id$='ddl_monthto']").val();
    var month= $("select[id$='ddl_month']").val();
     //$("input[id$='hdn_month']").val(month);
    if(month1 =="0")
    {
        $('#div_caerror').show();
        $('#spn_caerror').text('Select Month');
         $("select[id$='ddl_monthto']").focus();
        return false;
    }
    else
    {
        if(parseInt(month)>parseInt(month1))
        {
             $('#div_caerror').show();
             $('#spn_caerror').text('From Month Can not be greater than To date');
               return false;
        }
        else
        {
             $('#div_caerror').hide();
            return true;
        }
       
    }
}



function showtablecontent(partno,operation,fix,month,year,mach)
{
two();

    comma=partno.split(",");
    var tbl='<div><table style="width:auto;background-color:#eefaff;border:solid 1px #000;"><tr><td><div style="margin-top:20px;"><table><tr><td><span class="spn" style="color:Navy;">No.of Fixture alert</span></td></tr><tr><td><span class="spn"  style="color:Gold;">No.of Fixture Calibrated</span></td></tr></table></div></td>';
    for(var count=0;count<comma.length;count++)
    {
        if(comma[count]=="")
        {
        }
        else
        {
            $.ajax({
                url:"../Master/Default.aspx/get_tablecontent",
                data:"{'Partno':'"+comma[count]+"','OPE':'"+operation+"','Fix':'"+fix+"','Month':'"+month+"','Year':'"+year+"','Mach':'"+mach+"'}",
                type:"POST",
                contentType:"application/json; charset=utf-8",
                dataType:"json",
                success: function(msg)
                {
                    if(msg.d!=null && msg.d!="")
                    {
                        for(var i=0;i<msg.d.length;i++)
                        {
                            tbl+='<td><div><table cellspacing="-10" cellpadding="2"><tr class="trclass1"><td class="tdclass"><span>'+msg.d[i].Partno+'</span></td><td style="width:10px;"></td></tr>';
                            tbl+='<tr><td style="text-align:center;"><span style="font-size:14px; font-family:arial;">'+msg.d[i].A_count+'</span></td></tr>';
                            tbl+='<tr><td style="text-align:center;"><span style="font-size:14px; font-family:arial;">'+msg.d[i].C_count+'</span></td></tr>';
                            tbl+='<table></div></td>';
                        }
                       tbl+='</tr></table></div>';
                       $("div[id$='div_tablecontent']").html(tbl);
                    }
                    else
                    {
                    }
                },
                error:function(error)
                {}
              });
            
        }
    }
    
}

//function loadfixturechange()
//{   
//    $.ajax({

//                url:"../Master/Default.aspx/editfixname",
//                //url:"../Reports/FixtureReport.aspx/loadfixchange",
//                data:"{}",
//                type:"POST",
//                contentType: "application/json; charset=utf-8",
//                dataType: "json",
//                success: function(msg)
//                {
//                    if(msg.d!=null)
//                    {
//                    }
//                },
//                error:function()
//                {}
//              }); 
//}

function loadfixturechange()
{
$.ajax({
//                url:"../Master/Default.aspx/getfixvalues",
                url:"../Reports/FixtureReport.aspx/loadfixchange",
                data:"{}",
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