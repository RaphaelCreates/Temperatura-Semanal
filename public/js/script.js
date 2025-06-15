document.addEventListener('DOMContentLoaded', () => {
    const apiUrl = 'http://localhost:5279/api/temperatures/report'; // Replace with your API URL

    fetch(apiUrl)
    .then(Response => {
        if (!Response.ok) {
            throw new Error('Network response was not ok');
        }
        return Response.json();
    })
    .then(data => {

        console.log('dados recebidos da Api', data);
    })
    .catch(error => {
        console.error('There was a problem with the fetch operation:', error);
    });
});