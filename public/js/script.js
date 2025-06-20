document.addEventListener('DOMContentLoaded', () => {
    const apiUrl = 'http://localhost:5279/api/temperatures/report'; 

    fetch(apiUrl)
        .then(response => { 
            if (!response.ok) {
                throw new Error(`Erro HTTP! Status: ${response.status}`);
            }
            return response.json(); 
        })
        .then(data => {
            console.log('Dados recebidos da API:', data); 

            // Seção de Resumo Semanal
            
            document.getElementById('media-temperaturas').textContent = data.media.toFixed(2);
            document.getElementById('maior-temperatura').textContent = data.TempMaior; 
            document.getElementById('dia-maior-temperatura').textContent = data.diaMaior; 
            document.getElementById('menor-temperatura').textContent = data.TempMenor; 
            document.getElementById('dia-menor-temperatura').textContent = data.diaMenor; 
            


            
            const dailyDataBody = document.getElementById('daily-data-body'); 
            dailyDataBody.innerHTML = ''; 

            
            data.dailyReports.forEach(dailyReport => { 
                const rowDiv = document.createElement('div');
                rowDiv.classList.add('grid', 'grid-cols-3', 'items-center', 'py-2', 'border-b', 'border-yellow-300', 'last:border-b-0');

                const diaDiv = document.createElement('div');
                diaDiv.textContent = dailyReport.dia; 

                const tempDiv = document.createElement('div');
                tempDiv.textContent = `${dailyReport.temperatura}°C`;
                tempDiv.classList.add('text-yellow-200');

                const climaDiv = document.createElement('div'); 
                climaDiv.textContent = dailyReport.clima; 

                rowDiv.appendChild(diaDiv);
                rowDiv.appendChild(tempDiv);
                rowDiv.appendChild(climaDiv);

                dailyDataBody.appendChild(rowDiv);
            });
            


            //  Alerta de Onda de Calor 
            const alertaOndaCalorDiv = document.getElementById('alerta-onda-calor'); 

            if (data.alertaOndaDeCalor) { // 'alertaOndaDeCalor' com 'a' minúsculo
                alertaOndaCalorDiv.classList.remove('hidden');
                alertaOndaCalorDiv.classList.add('flex');
            } else {
                alertaOndaCalorDiv.classList.add('hidden');
                alertaOndaCalorDiv.classList.remove('flex');
            }
            

        })
        .catch(error => {
            console.error('Houve um problema com a requisição:', error);
        });
});