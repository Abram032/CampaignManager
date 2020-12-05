import React, { Component } from 'react';
import DataGridExp from '../../libs/components/forms/DataGridExp';
import { objectStore } from '../../stores/objectStore';
import { categoryStore } from '../../stores/categoryStore';
import { subcategoryStore } from '../../stores/subcategoryStore';

const types = {
  store: {
    type: 'array',
    data: [
      { id: 0, name: 'Unknown' },
      { id: 1, name: 'Infantry' },
      { id: 2, name: 'Vehicle' },
      { id: 3, name: 'Static' },
      { id: 4, name: 'Armament' },
      { id: 5, name: 'Consumable' },
      { id: 6, name: 'Miscellaneous' },
    ],
    key: 'id'
  }
}

const columns = [
  { dataField: 'id', caption: 'Id', dataType: 'number', allowEditing: false },
  { dataField: 'name', caption: 'Name', dataType: 'string', validationRules: [
    { type: 'required' },
    { type: 'stringLength', min: 1, max: 100 }
  ]},
  { dataField: 'type', caption: 'Type', validationRules: [
    { type: 'required' }
    ], lookup: {
      dataSource: types,
      valueExpr: 'id',
      displayExpr: 'name'
  }},
  { dataField: 'categoryId', caption: 'Category', validationRules: [
      { type: 'required' }
    ], lookup: {
      dataSource: categoryStore,
      valueExpr: 'id',
      displayExpr: 'name'
  }},
  { dataField: 'subcategoryId', caption: 'Subcategory', validationRules: [
      { type: 'required' }
    ], lookup: {
      dataSource: subcategoryStore,
      valueExpr: 'id',
      displayExpr: 'name'
    }},
  { dataField: 'defaultCost', caption: 'Default cost', dataType: 'number', validationRules: [
    { type: 'range', min: 0, max: 79228162514264337593543950335 }
  ]}
];

export class Objects extends Component {
  constructor(props) {
    super(props);
  };

  render() {
    return (
      <>
        <h1 className="display-4">Objects</h1>
        <DataGridExp columns={columns} store={objectStore}/>
      </>
    );
  }
};

export default Objects;