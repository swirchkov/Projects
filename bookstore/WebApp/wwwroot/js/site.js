var deleteBook = function(bookId) {
    $.post("/Home/DeleteBook", { bookId : bookId}, function (data) {
        if (data.success) {
            window.location.reload();
        }
        else {
            // code for error handling
        }
    })
};
