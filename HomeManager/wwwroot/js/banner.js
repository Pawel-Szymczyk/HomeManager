

window.onload = function () {
    loadBanner();
}


// Function responsible for loading different background image depends on time frame.
// e.g. between 5am and 10am function loads "morning" background.
function loadBanner() {
    let urlString;
    let banner = document.getElementById("pc-builder-banner");
    let curHr = new Date().getHours();

    if (curHr >= 5 && curHr < 10) {
        urlString = 'url(/lib/images/morning.png)';
        banner.style.backgroundImage = urlString;
    } else if (curHr >= 10 && curHr < 12) {
        urlString = 'url(/lib/images/late_morning.png)';
        banner.style.backgroundImage = urlString;
    } else if (curHr >= 12 && curHr < 15) {
        urlString = 'url(/lib/images/afternoon.png)';
        banner.style.backgroundImage = urlString;
    } else if (curHr >= 15 && curHr < 18) {
        urlString = 'url(/lib/images/late_afternoon.png)';
        banner.style.backgroundImage = urlString;
    } else if (curHr >= 18 && curHr < 20) {
        urlString = 'url(/lib/images/evening.png)';
        banner.style.backgroundImage = urlString;
    } else if (curHr >= 20 && curHr < 22) {
        urlString = 'url(/lib/images/late_evening.png)';
        banner.style.backgroundImage = urlString;
    } else if (curHr >= 22 && curHr < 24) {
        urlString = 'url(/lib/images/night.png)';
        banner.style.backgroundImage = urlString;
    } else {
        urlString = 'url(/lib/images/late_night.png)';
        banner.style.backgroundImage = urlString;
    }
}