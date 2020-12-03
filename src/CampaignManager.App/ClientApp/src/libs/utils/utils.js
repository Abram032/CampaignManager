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

    let request = {
        method: method,
        headers: {
          'Content-Type': 'application/json'
        },
        credentials: 'include'
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
                data: response,
                //totalCount: response.length
            });
        }
        if(method === 'POST') {
            const response = await result.json();
            return response;
        }
    } else {
      throw await result.json();
    }
}