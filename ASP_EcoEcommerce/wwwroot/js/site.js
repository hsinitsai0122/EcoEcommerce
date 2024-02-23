// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#filterPopularity').change(function () {
        var selectedOption = $(this).val();

        if (selectedOption === "Highest to Lowest") {
            window.location.href = '/Product/FilterByPopularity';
        }
    });
});

    $(document).ready(function() {
        $('#showAllProductsButton').click(function () {
            window.location.href = '/Product/AllProducts';
        });
    });

$(document).ready(function () {
    $('#filterCategory').change(function () {
        var selectedOption = $(this).val();

        if (selectedOption === "Grocery") {
            window.location.href = '/Product/FilterByCategory/Grocery';
        }
        if (selectedOption === "Electronics") {
            window.location.href = '/Product/FilterByCategory/Electronics';
        }
        if (selectedOption === "Beauty") {
            window.location.href = '/Product/FilterByCategory/Beauty';
        }

       
    });
});


$(document).ready(function () {
    $('#filterEcoScore').change(function () {
        var selectedOption = $(this).val();

        if (selectedOption === "A") {
            window.location.href = '/Product/FilterByEcoScore/A';
        }
        if (selectedOption === "B") {
            window.location.href = '/Product/FilterByEcoScore/B';
        }
        if (selectedOption === "C") {
            window.location.href = '/Product/FilterByEcoScore/C';
        }
        if (selectedOption === "D") {
            window.location.href = '/Product/FilterByEcoScore/D';
        }
        if (selectedOption === "E") {
            window.location.href = '/Product/FilterByEcoScore/E';
        }

    });
});

$(document).ready(function () {
    $('#searchInput').on('input', function () {
        var productName = $(this).val();
        if (productName.trim() !== '') {
            $.ajax({
                url: '/Product/FilterByName',
                type: 'GET',
                data: { name: productName },
                success: function (response) {
                    // Update the frontend with the search results
                    $('#productListContainer').html(response);
                },
                error: function (xhr, status, error) {
                    console.error(xhr.responseText);
                }
            });
        }
    });
});




