// Function to toggle the navigation menu's visibility
function toggleNavigation() {
  var nav = document.querySelector('nav');
  var isExpanded = nav.getAttribute('aria-expanded') === 'true';
  nav.setAttribute('aria-expanded', !isExpanded);
  document.getElementById('nav-list').style.display = isExpanded ? 'none' : 'flex';
}

// Event listener for the hamburger menu button
document.getElementById('hamburger-menu').addEventListener('click', toggleNavigation);

function filterProjects(category) {
  const projects = document.querySelectorAll('section.project, article.project');
  projects.forEach(project => {
    if (project.id.includes(category)) {
      project.style.display = 'block';
    } else {
      project.style.display = 'none';
    }
  });
}

const lightbox = document.getElementById('lightbox');
const lightboxImg = document.getElementById('lightbox-img');
const closeBtn = document.querySelector('.close');

document.querySelectorAll('.project img').forEach(img => {
  img.addEventListener('click', function() {
    lightbox.style.display = 'block';
    lightboxImg.src = this.src;
  });
});

closeBtn.addEventListener('click', function() {
  lightbox.style.display = 'none';
});

window.addEventListener('click', function(e) {
  if (e.target === lightbox) {
    lightbox.style.display = 'none';
  }
});

document.getElementById('contactForm').addEventListener('submit', function(event) {
  let valid = true;

  const name = document.getElementById('name').value;
  const email = document.getElementById('email').value;
  const message = document.getElementById('message').value;

  // Clear previous error messages
  document.getElementById('nameError').style.display = 'none';
  document.getElementById('emailError').style.display = 'none';
  document.getElementById('messageError').style.display = 'none';

  // Validate name
  if (!name) {
    document.getElementById('nameError').style.display = 'block';
    valid = false;
  }

  // Validate email
  const emailPattern = /^[^ ]+@[^ ]+\.[a-z]{2,3}$/;
  if (!email || !emailPattern.test(email)) {
    document.getElementById('emailError').style.display = 'block';
    valid = false;
  }

  // Validate message
  if (!message) {
    document.getElementById('messageError').style.display = 'block';
    valid = false;
  }

  // Prevent form submission if not valid
  if (!valid) {
    event.preventDefault();
  }
});

