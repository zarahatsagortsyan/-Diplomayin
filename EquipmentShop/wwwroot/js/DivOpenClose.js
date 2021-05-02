jQuery(document).ready(function () {
    jQuery(".cat_table_container").hide();
    jQuery(".cat_table_container:first").show();
});

function show_hide_table(table) {
    table = jQuery(table).parent().find(".cat_table_container");
    if (jQuery(table).is(":visible")) {
        if (jQuery(table).parents(".cat_container").attr("class") != "cat_container cat_container_parent") {
            if (jQuery(".cat_container_parent .cat_table_container").length > 0)
                jQuery(table).hide();
        }
    }
    else {
        jQuery(".cat_table_container").hide();
        jQuery(".cat_container_parent .cat_table_container").show();
        jQuery(table).show();
    }
}