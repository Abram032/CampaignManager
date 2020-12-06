import React, { Component } from 'react';
import DataGridExp from '../../libs/components/forms/DataGridExp';
import { categoryStore } from '../../stores/categoryStore';
import { subcategoryStore } from '../../stores/subcategoryStore';

const columns = [
  { dataField: 'id', caption: 'Id', dataType: 'number', allowEditing: false },
  { dataField: 'name', caption: 'Name', dataType: 'string', validationRules: [
    { type: 'required' },
    { type: 'stringLength', min: 1, max: 100 }
  ]}
];

export class Subcategories extends Component {
  render() {
    return (
      <>
        <h1 className="display-4">Subcategories</h1>
        <DataGridExp columns={columns} store={subcategoryStore}/>
      </>
    );
  }
};

export default Subcategories;