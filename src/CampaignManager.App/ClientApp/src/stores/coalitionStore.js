import CustomStore from 'devextreme/data/custom_store';

const apiUri = `${window.location.origin}/api/coalition`;
const coalitions = [];

export const coalitionStore = new CustomStore({
    key: 'id',
    load: () => sendRequest(`${apiUri}`),
    insert: (data) => sendRequest(`${apiUri}`, 'POST', JSON.stringify(data)),
    update: (key, data) => sendRequest(`${apiUri}/${key}`, 'PUT', JSON.stringify(data)),
    remove: (key) => sendRequest(`${apiUri}/${key}`, 'DELETE'),
});

const sendRequest = async (url, method, data) => {
    debugger;

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
    debugger;
    if(result.ok) {
        if(method === 'GET') {
            const response = await result.json();
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

// const sendRequest = (url, method, data) => {
//     debugger;
//     method = method || 'GET';
//     data = data || {};

//     console.log(method, url, data);

//     if(method === 'GET') {
//       return fetch(url, {
//         method: method,
//         credentials: 'include'
//       }).then(result => result.json().then(json => {
//           debugger;
//         if(result.ok) {
//             return ({
//                 data: json,
//                 totalCount: json.length
//             });
//         }
//         throw json.Message;
//       }));
//     }
// };