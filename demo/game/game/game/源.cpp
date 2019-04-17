
#include <iostream>
#include <windows.h>
#include <ctime>
#include<conio.h>

using namespace std;
//��ʼ��
//�������
int const NP = 4;
//��ͼ��С
int const ROW = 4;
int const COL = 4;
//��������
int const UP = 1;
int const DOWN = 2;
int const LEFT = 3;
int const RIGHT = 4;
//����ʹ��
int	const USE_0 = 10;
int	const USE_1 = 11;
int	const USE_2 = 12;
int	const USE_3 = 13;
int	const USE_4 = 14;
int	const USE_5 = 15;
int	const USE_6 = 16;
int	const USE_7 = 17;
int	const USE_8 = 18;
int	const USE_9 = 19; 
//map
class Map {

public:

	int map[ROW][COL] = { 0 };
	int pp[NP] = { 0 };//���λ��

	Map() {
		for (int i = 0; i < ROW; i++) {
			for (int j = 0; j < COL; j++) {
				map[i][j] =rand() % 10;//����ˢ��
			}
		}
	}

	void placePlayer(int n) {
		int i = pp[n] / ROW;
		int j = pp[n] % COL;
		map[i][j] = map[i][j] + 10 * (n + 1);
	}

	void removePlayer(int n) {
		int i = pp[n] / ROW;
		int j = pp[n] % COL;
		map[i][j] = map[i][j] - 10 * (n + 1);
	}

	int existPlayer(int p) {
		int i = p / ROW;
		int j = p % COL;
		return map[i][j] / 10;
	}

	void addPlayer() {
		//������д����� rand()%(ROW*COL)���ų��ظ� 
		for (int n = 0; n < NP; n++) {
			pp[0] = 0;
			pp[1] = 1;
			pp[2] = 2;
			pp[3] = 3;
			placePlayer(n);
		}
	}

	void refreshMap() {
		for (int i = 0; i < ROW; i++) {
			for (int j = 0; j < COL; j++) {
				map[i][j] = (map[i][j] / 10) * 10 + (rand() % 10);//���λ�ò���+����ˢ��
			}
		}
	};
}mainmap;
//player
class Player {

public:

	int pow;//�ж���
	int exp;//����-�ȼ�
	int sight;//��Ұ
	int hp;//Ѫ��
	
	int backpack[10];//���� backpack[0]��ӦItem_0 ��ֵ��Ӧ����
	/*
	**	backpack[1] = 1; ľ�� 2��1����
	**	backpack[2] = 1; ľ�� 1�� �ܷܶ���2��
	*/
	Player() { pow = 1; exp = 0; sight = 1; hp = 10; backpack[1] = 1; backpack[2] = 1; }

	//����������� ���ڿ��԰��ƶ���ʹ�õ��߷ֿ�
	int select()
	{
		//��������
		int feedback = 0;
		//��ȡ�����
		int upArrow = 0,
			downArrow = 0,
			leftArrow = 0,
			rightArrow = 0;
		//��ȡ�����ȼ�
		int item_0 = 0,
			item_1 = 0,
			item_2 = 0,
			item_3 = 0,
			item_4 = 0,
			item_5 = 0,
			item_6 = 0,
			item_7 = 0,
			item_8 = 0,
			item_9 = 0;
		while (true)
		{
			upArrow		=	GetAsyncKeyState(VK_UP);
			downArrow	=	GetAsyncKeyState(VK_DOWN);
			leftArrow	=	GetAsyncKeyState(VK_LEFT);
			rightArrow	=	GetAsyncKeyState(VK_RIGHT);
			//С����0-9
			item_0		=	GetAsyncKeyState(VK_NUMPAD0);
			item_1		=	GetAsyncKeyState(VK_NUMPAD1);
			item_2		=	GetAsyncKeyState(VK_NUMPAD2);
			item_3		=	GetAsyncKeyState(VK_NUMPAD3);
			item_4		=	GetAsyncKeyState(VK_NUMPAD4);
			item_5		=	GetAsyncKeyState(VK_NUMPAD5);
			item_6		=	GetAsyncKeyState(VK_NUMPAD6);
			item_7		=	GetAsyncKeyState(VK_NUMPAD7);
			item_8		=	GetAsyncKeyState(VK_NUMPAD8);
			item_9		=	GetAsyncKeyState(VK_NUMPAD9);

			if (upArrow)		 { feedback = UP;	 break; }
			else if (downArrow)  { feedback = DOWN;	 break; }
			else if (leftArrow)	 { feedback = LEFT;	 break; }
			else if (rightArrow) { feedback = RIGHT; break; }
			else if (item_0) { feedback = USE_0; break; }
			else if (item_1) { feedback = USE_1; break; }
			else if (item_2) { feedback = USE_2; break; }
			else if (item_3) { feedback = USE_3; break; }
			else if (item_4) { feedback = USE_4; break; }
			else if (item_5) { feedback = USE_5; break; }
			else if (item_6) { feedback = USE_6; break; }
			else if (item_7) { feedback = USE_7; break; }
			else if (item_8) { feedback = USE_8; break; }
			else if (item_9) { feedback = USE_9; break; }

			Sleep(100);
			
		}

		return feedback;
	}

}player[NP];

//action  �ص㣡���� ���ڿ��԰�ÿһ��action����һ�������
class Action {

public:

	int performAction(int n) {
		int k = player[n].select();
		switch (k)
		{
		case UP:
			if (mainmap.pp[n] / ROW == 0 || mainmap.existPlayer(mainmap.pp[n] - 4)) {
				cout << "invalid operation\n";
				return 1;
			}
			else {
				mainmap.removePlayer(n);
				mainmap.pp[n] -= 4;
				mainmap.placePlayer(n);
				player[n].exp++; player[n].pow--;
				return 0;
			}
			break;
		case DOWN:
			if (mainmap.pp[n] / ROW == ROW - 1 || mainmap.existPlayer(mainmap.pp[n] + 4)) {
				cout << "invalid operation\n";
				return 1;
			}
			else {
				mainmap.removePlayer(n);
				mainmap.pp[n] += 4;
				mainmap.placePlayer(n);
				player[n].exp++; player[n].pow--;
				return 0;
			}
			break;
		case LEFT:
			if (mainmap.pp[n] % COL == 0 || mainmap.existPlayer(mainmap.pp[n] - 1)) {
				cout << "invalid operation\n";
				return 1;
			}
			else {
				mainmap.removePlayer(n);
				mainmap.pp[n] -= 1;
				mainmap.placePlayer(n);
				player[n].exp++; player[n].pow--;
				return 0;
			}
			break;
		case RIGHT:
			if (mainmap.pp[n] % COL == COL - 1 || mainmap.existPlayer(mainmap.pp[n] + 1)) {
				cout << "invalid operation\n";
				return 1;
			}
			else {
				mainmap.removePlayer(n);
				mainmap.pp[n] += 1;
				mainmap.placePlayer(n);
				player[n].exp++; player[n].pow--;
				return 0;
			}
			break;
		case USE_0:
			cout << "invalid operation\n";
			return 1;
			break;
		case USE_1:
			cout << "Use WASD to select the attack target.\n";
			Sleep(20);
			{
				int attack_target = 0, aim = 0,
					up = 0, down = 0, left = 0, right = 0;
				while (attack_target == 0)
				{
					up = GetAsyncKeyState('W');
					down = GetAsyncKeyState('S');
					left = GetAsyncKeyState('A');
					right = GetAsyncKeyState('D');
					Sleep(50);
					up = GetAsyncKeyState('W');
					down = GetAsyncKeyState('S');
					left = GetAsyncKeyState('A');
					right = GetAsyncKeyState('D');

					if (up) { attack_target = -4; }
					else if (down) { attack_target = +4; }
					else if (left) { attack_target = -1; }
					else if (right) { attack_target = +1; }
				}
				aim = mainmap.existPlayer(mainmap.pp[n] + attack_target);
				if (aim && player[aim-1].hp) {
					cout << "ATTACK\n";
					int damage = (player[n].backpack[1]) * 2 - player[aim-1].backpack[2];
					player[aim-1].hp -= damage;
					player[n].pow--;
					cout << "- " << damage << endl;
					return 0;
				}
				else {
					cout << "Target Not Find\n";
					return 1;
				}
			}
			return 0;
			break;
		case USE_2:
			cout << "You lifted the shield.\n";
			player[n].pow--;
			player[n].backpack[2] += 1;
			return 0;
			break;
		case USE_3:
			cout << "invalid operation\n";
			return 1;
			break;
		case USE_4:
			cout << "invalid operation\n";
			return 1;
			break;
		case USE_5:
			cout << "invalid operation\n";
			return 1;
			break;
		case USE_6:
			cout << "invalid operation\n";
			return 1;
			break;
		case USE_7:
			cout << "invalid operation\n";
			return 1;
			break;
		case USE_8:
			cout << "invalid operation\n";
			return 1;
			break;
		case USE_9:
			cout << "PASS\n";
			player[n].pow = 0;
			return 0;
			break;
		default:
			cout << "invalid operation\n";
			return 1;
		}
	}
}action;

//��Ʒ ��ʱû�� ��Ϲ�༸��
class Item {
	int
		Item_0 = 0,//���� �Զ�ʧЧ ûд
		Item_1 = 1,//���� �˺��ͷ�Χ δ��� ��Χûд
		Item_2 = 2,//���� ���� �Զ���ЧIAO
		Item_3 = 3,//��Ѫ ûд
		Item_4 = 4,//���� ûд
		Item_5 = 5,//ûд
		Item_6 = 6,//ûд
		Item_7 = 7,//ûд
		Item_8 = 8,//ûд
		Item_9 = 9;//�����غ�
};

//square ��map��Ԫ��
//������
/*class Square {

public:

	int  num;

	int getItem(int i, int j) {
		return map[i][j] % 10;
	}; //0-9�ǵ���0-9

	int getPlayer(int i, int j) {
		return map[i][j] / 10;
	};//0�������1-4�����1-4
};*/

//�����ֱ��
int getItem(int i, int j) {
	return mainmap.map[i][j] % 10;
}; //0-9�ǵ���0-9

int getPlayer(int i, int j) {
	return mainmap.map[i][j] / 10;
};//0�������1-4�����1-4


//��ӡ���õ�����
void Print()
{
	system("cls");
	for (int i = 0; i < ROW; ++i)
	{
		cout << "---------------------------------" << endl;
		for (int j = 0; j < COL; ++j)
		{
			if (mainmap.map[i][j] / 10) {
				cout << "|   P" << mainmap.map[i][j] / 10 << "\t";
			}
			else {
				cout << "|   \t";
			}
		}
		cout << "|" << endl;
		for (int j = 0; j < COL; ++j)
		{
			cout << "|   " << mainmap.map[i][j] % 10 << "\t";
		}
		cout << "|" << endl;
	}
	cout << "---------------------------------" << endl;
}


int main()
{
	//����һ�����������
	srand((unsigned int)time(0));

	mainmap.addPlayer();
	Print();
	
	while (true) {

		for (int n = 0; n < NP; n++) {

			int  invalid_operation = 1;
			while (player[n].hp > 0 && player[n].pow > 0) {
				do {
					Print();
					cout << "P" << n + 1 << "'s turn:\tPOWER\t" << player[n].pow
						<< "\tEXP\t" << player[n].exp << "\tHP\t" << player[n].hp << endl
						<< "Press arrow keys to move,num keys to use props.\n";

					invalid_operation = action.performAction(n);

					Sleep(500);

					//_getch();

				} while (invalid_operation);

				Print();

			}
		}
		
		for (int n = 0; n < NP; n++) {
			if (player[n].hp == 0) {
				cout << "P" << n + 1 << "waste";
				player[n].exp = -1;
				player[n].pow = 0;
				break;
			}
			else {
				player[n].pow = player[n].exp + 1;
			}
		}

		mainmap.refreshMap();
		Print();
		Sleep(50);
	}
	system("pause");
	
	return 0;
}