unit Dialogs;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics,
  Controls, Forms, Dialogs, StdCtrls
type
  TSaveDialog=class(TForm)
    procedure Execute(Sender : TObject);
    procedure _PROC_0043F958(Sender : TObject);
    procedure _PROC_0043F9C0(Sender : TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end ;

var
  SaveDialog: TSaveDialog;

{This file is generated by DeDe Ver 3.50.04 Copyright (c) 1999-2002 DaFixer}

implementation

{$R *.DFM}

procedure TSaveDialog.Execute(Sender : TObject);
begin
(*
004408E0   53                     push    ebx
004408E1   56                     push    esi
004408E2   8BF2                   mov     esi, edx
004408E4   8BD8                   mov     ebx, eax

* Possible String Reference to: '�%��L'
|
004408E6   BA58C04300             mov     edx, $0043C058
004408EB   8BCE                   mov     ecx, esi
004408ED   8BC3                   mov     eax, ebx

|
004408EF   E84CF9FFFF             call    00440240
004408F4   83F801                 cmp     eax, +$01
004408F7   1BC0                   sbb     eax, eax
004408F9   40                     inc     eax
004408FA   5E                     pop     esi
004408FB   5B                     pop     ebx
004408FC   C3                     ret

*)
end;

procedure TSaveDialog._PROC_0043F958(Sender : TObject);
begin
(*
0043F958   55                     push    ebp
0043F959   8BEC                   mov     ebp, esp
0043F95B   53                     push    ebx
0043F95C   56                     push    esi
0043F95D   57                     push    edi
0043F95E   8B750C                 mov     esi, [ebp+$0C]
0043F961   8B5D08                 mov     ebx, [ebp+$08]
0043F964   33FF                   xor     edi, edi
0043F966   81FE10010000           cmp     esi, $00000110
0043F96C   7548                   jnz     0043F9B6
0043F96E   8BC3                   mov     eax, ebx

|
0043F970   E82FFFFFFF             call    0043F8A4
0043F975   A130354C00             mov     eax, dword ptr [$004C3530]
0043F97A   89583C                 mov     [eax+$3C], ebx
0043F97D   A130354C00             mov     eax, dword ptr [$004C3530]
0043F982   8B4044                 mov     eax, [eax+$44]
0043F985   50                     push    eax
0043F986   6AFC                   push    $FC
0043F988   53                     push    ebx

* Reference to: user32.SetWindowLongA()
|
0043F989   E88688FCFF             call    00408214
0043F98E   8B1530354C00           mov     edx, [$004C3530]
0043F994   894234                 mov     [edx+$34], eax
0043F997   8B4514                 mov     eax, [ebp+$14]
0043F99A   50                     push    eax
0043F99B   8B4510                 mov     eax, [ebp+$10]
0043F99E   50                     push    eax
0043F99F   56                     push    esi
0043F9A0   53                     push    ebx
0043F9A1   A130354C00             mov     eax, dword ptr [$004C3530]
0043F9A6   8B4044                 mov     eax, [eax+$44]
0043F9A9   50                     push    eax

* Reference to: user32.CallWindowProcA()
|
0043F9AA   E87583FCFF             call    00407D24
0043F9AF   33C0                   xor     eax, eax
0043F9B1   A330354C00             mov     dword ptr [$004C3530], eax
0043F9B6   8BC7                   mov     eax, edi
0043F9B8   5F                     pop     edi
0043F9B9   5E                     pop     esi
0043F9BA   5B                     pop     ebx
0043F9BB   5D                     pop     ebp
0043F9BC   C21000                 ret     $0010

*)
end;

procedure TSaveDialog._PROC_0043F9C0(Sender : TObject);
begin
(*
0043F9C0   0CFA                   or      al, $FA
0043F9C2   43                     inc     ebx
0043F9C3   0000                   add     [eax], al

*)
end;

end.