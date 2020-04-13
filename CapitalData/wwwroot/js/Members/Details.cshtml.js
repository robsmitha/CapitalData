


var MembersDetailsModule = MembersDetailsModule || (function () {
    // private
    var _args = {};

    var _initDataTables = function () {
        $('#tbl_terms').DataTable({
            "pageLength": 25,
            order: [[0, 'desc']]
        });
    }

    return {
        init: function (Args) {
            _args = Args;
            _initDataTables();
        }
    };
}());
