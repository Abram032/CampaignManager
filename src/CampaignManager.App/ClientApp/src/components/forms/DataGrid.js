import React, { Component } from 'react';
import {
  EditingState,
  SortingState,
  IntegratedSorting,
  PagingState,
  IntegratedPaging,
  FilteringState,
  IntegratedFiltering,
  GroupingState,
  IntegratedGrouping,
  RowDetailState
} from '@devexpress/dx-react-grid';
import {
  Grid,
  Table,
  TableHeaderRow,
  TableGroupRow,
  TableEditRow,
  TableEditColumn,
  PagingPanel,
  TableFilterRow,
  GroupingPanel,
  DragDropProvider,
  Toolbar,
  TableColumnReordering,
  TableColumnResizing,
  ColumnChooser,
  TableColumnVisibility,
  TableRowDetail
} from '@devexpress/dx-react-grid-bootstrap4';

export class DataGrid extends Component {

  constructor(props) {
    super(props);
    this.state = { 
      columns: [
        { name: 'id', title: 'Id' },
        { name: 'name', title: 'Name' },
        { name: 'type', title: 'Type' },
      ],
      rows: [
        { id: '1', name: 'Air-Superiority Fighter', type: 'Fighter' },
        { id: '2', name: 'Attack Aircraft', type: 'Attack' },
        { id: '3', name: 'Reconissance Aircraft', type: 'Fighter' },
        { id: '4', name: 'Multi-role Aircraft', type: 'Fighter' }
      ],
      grouping: [],
      currentPage: 1,
      pageSize: 10
    }
  }

  commitChanges = ({ added, changed, deleted }) => {
    let changedRows;
    if (added) {
      const startingAddedId = this.state.rows.length > 0 ? this.state.rows[this.state.rows.length - 1].id + 1 : 0;
      changedRows = [
        ...this.state.rows,
        ...added.map((row, index) => ({
          id: startingAddedId + index,
          ...row,
        })),
      ];
    }
    if (changed) {
      changedRows = this.state.rows.map(row => (changed[row.id] ? { ...row, ...changed[row.id] } : row));
    }
    if (deleted) {
      const deletedSet = new Set(deleted);
      changedRows = this.state.rows.filter(row => !deletedSet.has(row.id));
    }
    this.setRows(changedRows);
  };

  setRows = (changedRows) => this.setState({ rows: changedRows });

  getRowId = row => row.id;

  setGrouping = (grouping) => this.setState({ grouping: grouping });
  setCurrentPage = (page) => this.setState({ currentPage: page });
  setPageSize = (size) => this.setState({ pageSize: size });

  RowDetail = ({ row }) => (
    <div>
      Details for
      {' '}
      {row.id}
      {' - '}
      {row.name}
      {' of type '}
      {row.type}
    </div>
  );

  render() {
    return (
        <div className="card">
          <Grid
            rows={this.state.rows}
            columns={this.state.columns}
            getRowId={this.getRowId}
          >
            <DragDropProvider />
            <EditingState
              onCommitChanges={this.commitChanges}
            />
            <SortingState
              defaultSorting={[{ columnName: 'id', direction: 'asc' }]}
            />
            <IntegratedSorting />
            <PagingState
              currentPage={this.state.currentPage}
              onCurrentPageChange={this.setCurrentPage}
              pageSize={this.state.pageSize}
              onPageSizeChange={this.setPageSize}
            />
            <IntegratedPaging />
            <FilteringState defaultFilters={[]} />
            <IntegratedFiltering />
            <GroupingState
              grouping={this.state.grouping}
              onGroupingChange={this.setGrouping}
            />
            <IntegratedGrouping />
            <RowDetailState
              defaultExpandedRowIds={[]}
            />
            <Table />
            <TableColumnReordering
              defaultOrder={['id', 'name', 'type']}
            />
            <TableColumnVisibility
              defaultHiddenColumnNames={[]}
            />
            <TableColumnResizing defaultColumnWidths={[
              { columnName: 'id', width: 200 },
              { columnName: 'name', width: 200 },
              { columnName: 'type', width: 200 },
            ]} />
            
            <TableGroupRow />
            <TableHeaderRow showSortingControls showGroupingControls />
            <TableEditColumn showAddCommand showEditCommand showDeleteCommand />
            <PagingPanel
              pageSizes={[1, 2, 3, 5, 10, 15]}
            />
            <TableFilterRow />
            <TableRowDetail
              contentComponent={this.RowDetail}
            />
            <TableEditRow />
            <Toolbar />
            <ColumnChooser />
            <GroupingPanel showGroupingControls />
          </Grid>
        </div>
      );
  }
};

export default DataGrid;
