import CustomStore from 'devextreme/data/custom_store';
import { sendRequest } from '../libs/utils/utils';

const apiUri = `${window.location.origin}/api/campaignEntity`;

export const campaignEntityStore = new CustomStore({
    key: 'id',
    byKey: (key) => sendRequest(`${apiUri}/${key}`),
    load: () => sendRequest(`${apiUri}`),
    load: (options) => sendRequest(`${apiUri}`, 'GET', null, options),
    insert: (data) => sendRequest(`${apiUri}`, 'POST', JSON.stringify(data)),
    update: (key, data) => sendRequest(`${apiUri}/${key}`, 'PUT', JSON.stringify(data)),
    remove: (key) => sendRequest(`${apiUri}/${key}`, 'DELETE')
});