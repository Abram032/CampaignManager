import CustomStore from 'devextreme/data/custom_store';
import { sendRequest } from '../libs/utils/utils';

const apiUri = `${window.location.origin}/api/object`;

export const objectStore = new CustomStore({
    key: 'id',
    load: () => sendRequest(`${apiUri}`),
    insert: (data) => sendRequest(`${apiUri}`, 'POST', JSON.stringify(data)),
    update: (key, data) => sendRequest(`${apiUri}/${key}`, 'PUT', JSON.stringify(data)),
    remove: (key) => sendRequest(`${apiUri}/${key}`, 'DELETE'),
});

const prepareData = (data) => {
    data.type = data.type.id;
    return JSON.stringify(data);
};

const parseData = ({ data }) => {
    debugger
    data.category = data.categoryId;
    data.subcategory = data.subcategoryId;
    return {
        data: data
    };
}