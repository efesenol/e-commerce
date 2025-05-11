document.addEventListener("DOMContentLoaded", function () {
    // Olay bağlama işlemini burada gerçekleştirebilirsiniz
    const heartIcons = document.querySelectorAll('.heart-icon');
    
    heartIcons.forEach(function (icon) {
        icon.addEventListener('click', function () {
            const productId = icon.getAttribute('data-id');

            // Görsel kalp değişimi
            icon.classList.toggle('liked');
            icon.classList.toggle('fa-solid');
            icon.classList.toggle('fa-regular');

            // Favori durumu güncelleme isteği
            fetch(`/Home/ToggleFavorite/${productId}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]')?.value
                }
            })
            .then(response => {
                if (!response.ok) {
                    throw new Error("Favori işlemi başarısız.");
                }
                return response.json();
            })
            .then(data => {
                console.log("Favori durumu güncellendi", data);
            })
            .catch(error => {
                console.error("Hata:", error);
            });
        });
    });
});
