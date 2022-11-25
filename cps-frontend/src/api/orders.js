const BASE_URL = 'https://localhost:7143';

export async function getOrders() {
    const requestOptions = {
		method: 'GET',
		headers: { 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*' },
	};
	const response = await fetch(`${BASE_URL}/Orders/GetOrders`, requestOptions);
	return response.json();
}

export async function uploadFile(formData){
 	const requestOptions = {
 		method: 'POST',
 		headers: {'Access-Control-Allow-Origin': '*' },
 		body: formData
 	};

    return await fetch(`${BASE_URL}/Orders/ImportOrders`, requestOptions);
}