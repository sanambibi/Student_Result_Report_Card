document.addEventListener('DOMContentLoaded', () => {
    document.querySelectorAll('.nav-link').forEach(link => {
        if (link.href === window.location.href) link.classList.add('active');
    });
    document.querySelectorAll('.count-up').forEach(el => {
        el.animate([{opacity:0, transform:'translateY(8px)'},{opacity:1, transform:'translateY(0)'}], {duration:650, easing:'ease-out'});
    });
});
