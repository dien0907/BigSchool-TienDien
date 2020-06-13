var courseController =
{
    init: function () {
        courseController.registerEvent();
    },
    registerEvent: function () {
        $('#btnCreateCourse').off('click').on('click', function () {
            alert("Create Successful");
        });
    },
}
courseController.init();