// Load connections from local storage when the page loads
window.addEventListener('DOMContentLoaded', function() {
    loadConnections();
    displayActiveConfigurations();
    toggleOverlay();
    closeOnEscape();
    //toggleOverlayupdate();
});

// Function to load connections from local storage
function loadConnections() {
    const connections = JSON.parse(localStorage.getItem('connections')) || [];
    displayConnections(connections);
}

// Function to display connections on the page
function displayConnections(connections) {
    const connectionList = document.getElementById('connectionList');
    connectionList.innerHTML = ''; // Clear previous connections
    connections.forEach(connection => {
        const listItem = document.createElement('li');
        listItem.textContent = connection;
        connectionList.appendChild(listItem);
    });
}

// Function to handle form submission (add/edit connection)
document.getElementById('connectionForm').addEventListener('submit', function(event) {
    event.preventDefault();
    const connectionTypeInput = document.getElementById('connectionType');
    const connectionType = connectionTypeInput.value.trim();
    if (connectionType === '') {
        alert('Please enter a connection type.');
        return;
    }
    addConnection(connectionType);
    connectionTypeInput.value = ''; // Clear input field
});

// Function to add a connection to local storage and display it
function addConnection(connectionType) {
    let connections = JSON.parse(localStorage.getItem('connections')) || [];
    connections.push(connectionType);
    localStorage.setItem('connections', JSON.stringify(connections));
    displayConnections(connections);
}

// Function to display active configurations on the page
function displayActiveConfigurations() {
    const activeConfigurations = JSON.parse(localStorage.getItem('connections')) || [];
    const activeConfigurationsList = document.getElementById('activeConfigurations');
    activeConfigurationsList.innerHTML = ''; // Clear previous list items
    activeConfigurations.forEach(configuration => {
        const listItem = document.createElement('li');
        listItem.textContent = configuration;
        activeConfigurationsList.appendChild(listItem);
    });
}

/*function toggleOverlay() {
            var overlay = document.getElementById('overlay');
            overlay.style.display = (overlay.style.display == 'none') ? 'block' : 'none';
        }
*/
function toggleOverlay() {
    var overlay = document.getElementById('overlay');
    if (overlay.style.display == 'none' || overlay.style.display == '') {
        overlay.style.display = 'block';
        // Add event listener to close overlay when Escape key is pressed
        document.addEventListener('keydown', closeOnEscape);
    } else {
        overlay.style.display = 'none';
        // Remove event listener when overlay is closed
        document.removeEventListener('keydown', closeOnEscape);
    }
}

function toggleOverlayupdate() {
    var overlay = document.getElementById('updateoverlay');
    if (overlay.style.display == 'none' || overlay.style.display == '') {
        overlay.style.display = 'block';
        // Add event listener to close overlay when Escape key is pressed
        document.addEventListener('keydown', closeOnEscape);
    } else {
        overlay.style.display = 'none';
        // Remove event listener when overlay is closed
        document.removeEventListener('keydown', closeOnEscape);
    }
}

// Function to close overlay when Escape key is pressed
function closeOnEscape(event) {
    if (event.key === "Escape") {
        toggleOverlay(); // Close overlay
    }
}