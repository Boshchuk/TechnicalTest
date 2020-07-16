interface IEmployeeListItem {
  id: number;
  name: string;
  lastName: string;
  isMediaInteractivaEmployee: boolean;
  animals: IAnimalListItem[];
}

interface IAnimalListItem {
  id: number;
  type: string;
  name: string;
  ownerDisplayName: string;
  owner: IEmployeeListItem;
}
