import React, { Component } from 'react';
import DataGridExp from '../../libs/components/forms/DataGridExp';
import { entityStore } from '../../stores/entityStore';
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
  { dataField: 'categoryId', caption: 'Category', 
    setCellValue: function(rowData, value) {
      rowData.categoryId = value;
      rowData.subcategoryId = null;
    },
    validationRules: [
      { type: 'required' }
    ], lookup: {
      dataSource: categoryStore,
      valueExpr: 'id',
      displayExpr: 'name'
  }},
  { dataField: 'subcategoryId', caption: 'Subcategory', validationRules: [
      { type: 'required' }
    ], lookup: {
      dataSource: function(options) {
        return {
          store: subcategoryStore,
          filter: options.data ? ['categoryId', '=', options.data.categoryId] : null
        };
      },
      valueExpr: 'id',
      displayExpr: 'name'
  }},
  { dataField: 'defaultCost', caption: 'Default cost', dataType: 'number', validationRules: [
    { type: 'range', min: 0, max: 79228162514264337593543950335 }
  ]}
];

export class Entities extends Component {
  constructor(props) {
    super(props);
  };

  render() {
    return (
      <>
        <h1 className="display-4">Entities</h1>
        <DataGridExp columns={columns} store={entityStore}/>
      </>
    );
  }
};

export default Entities;