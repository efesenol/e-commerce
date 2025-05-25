document.addEventListener("DOMContentLoaded", function () {
    let loginCheckDone = false;

    const heartIcons = document.querySelectorAll('.heart-icon');

    heartIcons.forEach(function (icon) {
        icon.addEventListener('click', function () {
            if (!loginCheckDone && userId === null) {
                loginCheckDone = true; // Sadece bir kez yönlendirme yapılacak
                window.location.href = "/Login"; // Giriş sayfası rotanıza göre değiştirin
                return;
            }

            const productId = icon.getAttribute('data-id');

            icon.classList.toggle('liked');
            icon.classList.toggle('fa-solid');
            icon.classList.toggle('fa-regular');

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
