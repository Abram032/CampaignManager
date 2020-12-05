import authService from '../../components/api-authorization/AuthorizeService';

export const isNullOrUndefined = (value) => {
    if(value === undefined || value === null) {
        return true;
    }
    return false;
}

export const sendRequest = async (url, method, data) => {

    method = method || 'GET';
    data = data || {};

    console.log(method, url, data);

    const token = await authService.getAccessToken();
    let request = {
        method: method,
        headers: {
            'Content-Type': 'application/json'
        },
        credentials: 'include'
    }

    if(token) {
        request.headers = { 
            ...request.headers, 
            'Authorization': `Bearer ${token}`
        };
    }

    if(method === 'POST' || method === 'PUT') {
        request.body = data;
    }

    const result = await fetch(url, request);
    if(result.ok) {
        if(method === 'GET') {
            const response = await result.json();
            console.log(method, url, response);
            return ({
                data: response
            });
        }
        if(method === 'POST') {
            const response = await result.json();
            return response;
        }
    } else {
      throw 'Something went wrong.';
    }
}