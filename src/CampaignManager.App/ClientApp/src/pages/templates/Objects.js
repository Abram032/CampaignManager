import React, { Component } from 'react';
import DataGridExp from '../../libs/components/forms/DataGridExp';
import { objectStore } from '../../stores/objectStore';
import { categoryStore } from '../../stores/categoryStore';
import { subcategoryStore } from '../../stores/subcategoryStore';
import { 
  DataGrid, 
  Column, 
  Editing, 
  Scrolling, 
  Lookup, 
  Summary, 
  TotalItem, 
  Paging, 
  Pager, 
  Grouping, 
  GroupPanel,
  FilterRow,
  HeaderFilter,
  SearchPanel,
  ColumnChooser, 
  ColumnFixing,
  MasterDetail,
  StringLengthRule,
  RequiredRule
} from 'devextreme-react/data-grid';

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

const columns = (
  [
    <Column dataField="id" dataType="number" caption="Id" allowEditing="false"></Column>,
    <Column dataField="name" dataType="string" caption="Name">
      <RequiredRule />
      <StringLengthRule min="1" max="100" />
    </Column>,
    <Column dataField="type" dataType="number" caption="Type">
      <Lookup 
        dataSource={types}
        valueExpr="id"
        displayExpr="name"
      />
      <RequiredRule />
    </Column>,
    <Column dataField="category" dataType="number" caption="Category">
      <Lookup 
        dataSource={categoryStore}
        valueExpr="id"
        displayExpr="name"
      />
      <RequiredRule />
    </Column>,
    <Column dataField="subcategory" dataType="number" caption="Subcategory">
      <Lookup 
        dataSource={subcategoryStore}
        valueExpr="id"
        displayExpr="name"
      />
      <RequiredRule />
    </Column>,
  ]
);

export class Objects extends Component {
  constructor(props) {
    super(props);
  };

  render() {
    return (
      <>
        <DataGridExp columns={columns} store={objectStore} useCustomColumns={true}/>
      </>
    );
  }
};

export default Objects;